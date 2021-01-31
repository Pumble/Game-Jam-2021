using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pun2Demo;

public class ScripAttack : MonoBehaviour
{
    // Start is called before the first frame update
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
            enemyPlayer.GetComponent<Player>().vida -= danno;
            Debug.Log("Enemigo Sufrio daño, vida actual " + enemyPlayer.GetComponent<Player>().vida);

            sound.PlayOneShot(audios[0]);

            if (enemyPlayer.GetComponent<Player>().vida <= 0)
            {
                Debug.Log("El jugador enemigo murio, regresa a la base ");
                Rigidbody2D CasaDuendes = GameObject.Find("CasaDuendes").GetComponent<Rigidbody2D>();
                if (enemyPlayer.GetComponent<Player>().tieneBandera)
                {
                    GameObject.Find("Flag").GetComponent<BoxCollider2D>().enabled = true;
                    enemyPlayer.GetComponent<Player>().tieneBandera = false;
                }


                enemyPlayer.GetComponent<Transform>().position = new Vector2(CasaDuendes.position.x, CasaDuendes.position.y);
                enemyPlayer.GetComponent<Player>().vida = 100f;
            }
            Destroy(this.gameObject, (float)0.3);
        }
        else
        {
            if (collision.CompareTag("Player") && this.gameObject.CompareTag("Trebol"))
            {
                GameObject player = GameObject.Find(collision.name);
                player.GetComponent<Player>().vida -= danno;
                Debug.Log("Sufrio daño, vida actual " + player.GetComponent<Player>().vida);

                sound.PlayOneShot(audios[0]);

                if (player.GetComponent<Player>().vida <= 0)
                {
                    Debug.Log("El jugador murio, regresa a la base ");
                    Rigidbody2D casaFamilia = GameObject.Find("CasaFamilia").GetComponent<Rigidbody2D>();
                    if (player.GetComponent<Player>().tieneBandera)
                    {
                        GameObject.Find("Flag").GetComponent<BoxCollider2D>().enabled = true;
                        player.GetComponent<Player>().tieneBandera = false;
                    }

                    player.GetComponent<Transform>().position = new Vector2(casaFamilia.position.x, casaFamilia.position.y);
                    player.GetComponent<Player>().vida = 100f;
                }
                Destroy(this.gameObject, (float)0.3);
            }
        }
        Destroy(this.gameObject, 3);
    }
}
