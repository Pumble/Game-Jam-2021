using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// USING AGREGADOS
using Pun2Demo;

public class Attack : MonoBehaviour
{
    public static AudioSource sound;
    public List<AudioClip> audios = new List<AudioClip>();

    public int damage;
    public bool destroy;

    /* 1- SE PUEDE MEJORAR SI LE AGREGAMOS UN SPAWN POINT POR DEFECTO A CADA
     * JUGADOR, ASI SI MUERE, YA SABE CUAL ES SU PUNTO DE SALIDA
     * 2- LA MUERTE Y EL DAÑO LO PODEMOS HACER POR EVENTOS, PARA ENCAPSULARLO
     * TODO EN EL MISMO PLAYER MOVEMENT, ALLO PODRIAMOS TENER EL SPAWPOINT
     */

    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
        destroy = GetComponent<Attack>().destroy;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject player = GameObject.Find(collision.name);
        Debug.Log(player.name);



        player.GetComponent<Player>().vida -= damage;
        Debug.Log("Sufrio daño: " + damage + ", vida actual: " + player.GetComponent<Player>().vida);
        sound.PlayOneShot(audios[0]);

        if (
            (collision.CompareTag("enemyPlayer") && this.gameObject.CompareTag("Chancleta"))
            ||
            (collision.CompareTag("Player") && this.gameObject.CompareTag("Trebol"))
        )
        {
            if (player.GetComponent<Player>().vida <= 0)
            {
                Debug.Log("El jugador enemigo murio, regresa a la base ");
                // Rigidbody2D CasaDuendes = GameObject.Find("CasaDuendes").GetComponent<Rigidbody2D>();
                if (player.GetComponent<Player>().tieneBandera)
                {
                    GameObject.Find("Flag").GetComponent<BoxCollider2D>().enabled = true;
                    player.GetComponent<Player>().tieneBandera = false;
                }

                // enemyPlayer.GetComponent<Transform>().position = new Vector2(CasaDuendes.position.x, CasaDuendes.position.y);
                player.GetComponent<Transform>().position = player.GetComponent<Player>().ReSpawnPoint.position;
                player.GetComponent<Player>().vida = 100f;
            }
            Destroy(this.gameObject, (float)0.3);
        }
        Destroy(this.gameObject, 3);
    }
}
