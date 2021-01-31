using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScripAttack : MonoBehaviour
{
    
    public static AudioSource sound;
    public List<AudioClip> audios = new List<AudioClip>();

    public int danno;
    public bool destruir;

    void Start()
    {
        sound = GetComponent<AudioSource>();
        destruir = GetComponent<ScripAttack>().destruir;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemyPlayer") && this.gameObject.CompareTag("Chancleta"))
        {
            GameObject enemyPlayer = GameObject.Find(collision.name);
            enemyPlayer.GetComponent<PlayerMovement>().vida -= danno;
            Debug.Log("Sufrio daño, vida actual " + enemyPlayer.GetComponent<PlayerMovement>().vida);

            sound.PlayOneShot(audios[0]);

            if (enemyPlayer.GetComponent<PlayerMovement>().vida <= 0)
            {
                Debug.Log("El jugador enemigo murio, regresa a la base ");
                Rigidbody2D CasaDuendes = GameObject.Find("CasaDuendes").GetComponent<Rigidbody2D>();
                if (enemyPlayer.GetComponent<PlayerMovement>().getTieneBandera())
                {
                    GameObject.Find("Bandera").GetComponent<BoxCollider2D>().enabled = true;
                    enemyPlayer.GetComponent<PlayerMovement>().setTieneBandera(false);
                }


                enemyPlayer.GetComponent<Transform>().position = new Vector2(CasaDuendes.position.x, CasaDuendes.position.y);
                enemyPlayer.GetComponent<PlayerMovement>().vida = 100f;
            }
            Destroy(this.gameObject, (float)0.3);
        }
        else {
            if (collision.CompareTag("Player") && this.gameObject.CompareTag("Trebol"))
            {
                GameObject player = GameObject.Find(collision.name);
                player.GetComponent<PlayerMovement>().vida -= danno;
                Debug.Log("Sufrio daño, vida actual " + player.GetComponent<PlayerMovement>().vida);

                sound.PlayOneShot(audios[0]);

                if (player.GetComponent<PlayerMovement>().vida <= 0)
                {
                    Debug.Log("El jugador murio, regresa a la base ");
                    Rigidbody2D casaFamilia = GameObject.Find("CasaFamilia").GetComponent<Rigidbody2D>();
                    if (player.GetComponent<PlayerMovement>().getTieneBandera())
                    {
                        GameObject.Find("Bandera").GetComponent<BoxCollider2D>().enabled = true;
                        player.GetComponent<PlayerMovement>().setTieneBandera(false);
                    }


                    player.GetComponent<Transform>().position = new Vector2(casaFamilia.position.x, casaFamilia.position.y);
                    player.GetComponent<PlayerMovement>().vida = 100f;
                    Destroy(this.gameObject, (float)0.3);
                }
            }
        }
        Destroy(this.gameObject, 3);
    }
}
