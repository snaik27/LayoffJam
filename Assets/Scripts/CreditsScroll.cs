using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsScroll : MonoBehaviour
{
    public GameObject plaque;
    private float speed = -1.0f;
    private Vector3 position = new Vector3(2f, 4f, 5f);
    public void SetPosition()
    {
        Rigidbody2D rb = plaque.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector3(speed, 0, 0);
        GetComponent<Transform>().position = position;
    }
}
