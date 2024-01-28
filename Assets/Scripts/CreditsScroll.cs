using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsScroll : MonoBehaviour
{
    public GameObject plaque;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = plaque.GetComponent<Rigidbody>();
        rb.velocity = new Vector3(-1.0f, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
