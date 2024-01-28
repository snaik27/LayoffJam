using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentToCamera : MonoBehaviour
{
    private void Start()
    {
        transform.SetParent(Camera.main.transform, true);
    }
}
