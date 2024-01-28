using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsScroll : MonoBehaviour
{
    public GameObject plaque;
    public float speed = -1f;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = plaque.GetComponent<Rigidbody>();
        rb.velocity = new Vector3(speed, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
