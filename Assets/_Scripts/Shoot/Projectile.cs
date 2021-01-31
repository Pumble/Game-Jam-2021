using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // REFERENCIA: https://www.youtube.com/watch?v=Qkh2IZoUNJo

    private Rigidbody2D rb;
    private Vector3 lastPosition;
    public float velocity;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.velocity = transform.right * velocity;
        lastPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (lastPosition != transform.position)
        {
            transform.right = transform.position - lastPosition;
            lastPosition = transform.position;
        }
    }
}
