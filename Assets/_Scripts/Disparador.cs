using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparador : MonoBehaviour
{
    public GameObject proyectil;
    public float distancia;
    public bool disparar = true;

    void Start()
    {
        distancia = 20f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (disparar)
            {
                disparar = false;
                Instantiate(proyectil, transform.position, transform.rotation);
                StartCoroutine("corrutinaDisparar");
            }
        }
    }

    public void setDistancia(float dista)
    {
        distancia = dista;
    }
    IEnumerator corrutinaDisparar()
    {
        yield return new WaitForSeconds((float)0.33);
        disparar = true;
    }
    // Codigo de https://www.youtube.com/watch?v=Qkh2IZoUNJo
}
