using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class CreditsScroll : MonoBehaviour
{
    public GameObject plaque;
    [SerializeField] float speed = -1.0f;
    private Vector3 originalPos = new Vector3(2f, 4f, 5f);

    public void Update()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;
    }

    public void ResetPosition()
    {
        transform.position = originalPos;
    }
}
