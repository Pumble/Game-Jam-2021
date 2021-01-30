using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pun2Demo;

public class ScripAttack : MonoBehaviour
{
    // Start is called before the first frame update
    public int danno;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameObject player = GameObject.Find(collision.name);
            player.GetComponent<PlayerMovement>().vida -= danno;
            Debug.Log("Sufrio daño, vida actual "+ player.GetComponent<PlayerMovement>().vida);

            if (player.GetComponent<PlayerMovement>().vida <= 0) {
                Debug.Log("El jugador murio, regresa a la base ");
                Rigidbody2D casaFamilia = GameObject.Find("CasaFamilia").GetComponent<Rigidbody2D>();
                if (player.GetComponent<PlayerMovement>().getTieneBandera()) {
                    GameObject.Find("Bandera").GetComponent<BoxCollider2D>().enabled = true;
                    player.GetComponent<PlayerMovement>().setTieneBandera(false);
                }


                player.GetComponent<Transform>().position = new Vector2(casaFamilia.position.x, casaFamilia.position.y);
                player.GetComponent<PlayerMovement>().vida = 100f;
            }
        }

    }
}
