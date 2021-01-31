using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pun2Demo;

public class ColliderBase : MonoBehaviour
{
    private int puntosAnotados;

    public static AudioSource sound;
    public List<AudioClip> audios = new List<AudioClip>();
    public bool casaFamilia;

    void Start()
    {
        sound = GetComponent<AudioSource>();
        casaFamilia = GetComponent<ColliderBase>().casaFamilia;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.CompareTag("Player")) && GameObject.Find(collision.name).GetComponent<Player>().tieneBandera && casaFamilia)
        {
            GameObject.Find(collision.name).GetComponent<Player>().tieneBandera = false;
            GameObject.Find("Flag").GetComponent<BoxCollider2D>().enabled = true;

            Transform UbicaconBandera = GameObject.Find("UbicaconBandera").GetComponent<Transform>();

            sound.PlayOneShot(audios[0]);

            GameObject.Find("Flag").GetComponent<Transform>().position = new Vector2(UbicaconBandera.position.x, UbicaconBandera.position.y);
            GameManager.setPuntosEquipoAliado(GameManager.getPuntosEquipoAliado() + 1);

            Debug.Log("Punto Anotado " + GameManager.getPuntosEquipoAliado());
        }
        else {
            if ((collision.CompareTag("enemyPlayer")) && GameObject.Find(collision.name).GetComponent<Player>().tieneBandera && !casaFamilia)
            {
                GameObject.Find(collision.name).GetComponent<Player>().tieneBandera = false;
                GameObject.Find("Flag").GetComponent<BoxCollider2D>().enabled = true;

                Transform UbicaconBandera = GameObject.Find("UbicaconBandera").GetComponent<Transform>();

                sound.PlayOneShot(audios[0]);

                GameObject.Find("Flag").GetComponent<Transform>().position = new Vector2(UbicaconBandera.position.x, UbicaconBandera.position.y);
                GameManager.setPuntosEquipoEnemigo(GameManager.getPuntosEquipoEnemigo() + 1);

                Debug.Log("Punto Anotado " + GameManager.getPuntosEquipoEnemigo());
            }
        }
    }
}
