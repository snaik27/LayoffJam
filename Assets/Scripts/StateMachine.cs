using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Example of how to use
/// 1. Create enum of States
/// public enum StateType{
///     State1,
///     State2,
///     State3
///     }
/// 2. Create statemachine
/// > _stateMachine = new StateMachine<StateType>(StateType.StartState, machine =>
///     {
///     machine.ConfigureState(StateType.State1, State1_Start, State1_Update, State1_End);
///     machine.ConfigureSt... (for each state)
///     }
/// 3. Define these functions in script
/// 4. Call Update on statemachine in Update() or when needed
/// </summary>
namespace SidTools
{

    //Class with a required enum
    public class StateMachine<State> where State : System.Enum
    {
        public State CurrentState { get; private set; }
         
        public struct StateDefinition
        {
            public Action OnStart;
            /// <summary>
            /// Float here is Total time spent in state
            /// </summary>
            public Action<float> OnUpdate; 
            public Action OnEnd;
        }

        private Dictionary<State, StateDefinition> _states = new Dictionary<State, StateDefinition>();
        private float _stateTime;
        private bool _stateInitialized = false;
        private bool _machineInitialized = false;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="startState"> The state that starts when the statemachine is created. </param>
        /// <param name="configure"> Use a lambda expression block to configure the states and state machine. Ref top of this script for example. </param>
        public StateMachine(State startState, Action<StateMachine<State>> configure)
        {
            _stateInitialized = false;
            configure(this);
            SetState(startState);
        }

        public void ConfigureState(State state, Action OnStart = null, Action<float> OnUpdate = null, Action OnEnd = null)
        {
            _states.Add(state, new StateDefinition()
            {
                OnStart = OnStart,
                OnUpdate = OnUpdate,
                OnEnd = OnEnd
            });
        }

        public void SetState(State state)
        {
            if (_machineInitialized && state.Equals(CurrentState))
            {
                return;
            }

            _machineInitialized = true;

            //End last state if there's a current state
            if (_stateInitialized)
            {
                if (_states.ContainsKey(CurrentState) && _states[CurrentState].OnEnd != null)
                {
                    _states[CurrentState].OnEnd();
                }
            }
            else
            {
                _stateInitialized = true;
            }

            CurrentState = state;
            _stateTime = 0f;

            //Start new state
            if (_states.ContainsKey(CurrentState))
            {
                if (_states[CurrentState].OnStart != null)
                {
                    _states[CurrentState].OnStart();
                }
            }

        }

        public void UpdateState()
        {
            if(_stateInitialized && _states.ContainsKey(CurrentState) && _states[CurrentState].OnUpdate != null)
            {
                _states[CurrentState].OnUpdate(_stateTime);
                _stateTime += Time.deltaTime; 
            }
        }
    }
}
