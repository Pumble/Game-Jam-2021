using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    private Rigidbody2D rb;
    public float velocidadChancleta;

    private Vector3 posicionPasada;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.velocity = transform.right * velocidadChancleta;
        posicionPasada = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (posicionPasada != transform.position) {
            transform.right = transform.position - posicionPasada;
            posicionPasada = transform.position;
        }
    }

    // Codigo de https://www.youtube.com/watch?v=Qkh2IZoUNJo
}
