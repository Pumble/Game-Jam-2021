using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pun2Demo;

public class ColliderBase : MonoBehaviour
{
    private int puntosAnotados;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && GameObject.Find(collision.name).GetComponent<PlayerMovement>().getTieneBandera())
        {
            GameObject.Find(collision.name).GetComponent<PlayerMovement>().setTieneBandera(false);
            GameObject.Find("Bandera").GetComponent<BoxCollider2D>().enabled = true;

            Rigidbody2D casaDuendes = GameObject.Find("CasaDuendes").GetComponent<Rigidbody2D>();
            /*
            Vector2 movement;
            movement.x = 0;
            movement.y = 0;

            GameObject.Find("Bandera").GetComponent<Rigidbody2D>().MovePosition(new Vector2(rigidbody2D.position.x, rigidbody2D.position.y) + movement * 5f * Time.fixedDeltaTime);
            */
            GameObject.Find("Bandera").GetComponent<Transform>().position = new Vector2(casaDuendes.position.x, casaDuendes.position.y);
            GameManager.setPuntosEquipoAliado(GameManager.getPuntosEquipoAliado() + 1);

            Debug.Log("Punto Anotado " + GameManager.getPuntosEquipoAliado());
        }
    }
}
