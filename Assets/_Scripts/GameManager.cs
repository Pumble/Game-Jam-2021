using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static int puntosEquipoAliado;
    private static int puntosEquipoEnemigo;
    private static float tiempoPartida;

    static AudioSource sound;
    public List<AudioClip> audios = new List<AudioClip>();

    public static bool partidaEnCurso;

    void Start()
    {
        puntosEquipoAliado = 0;
        puntosEquipoEnemigo = 0;
        tiempoPartida = 30;

        sound = GetComponent<AudioSource>();
        sound.PlayOneShot(audios[0]);
        partidaEnCurso = true;

    }

    // Update is called once per frame
    void Update()
    {
        tiempoPartida -= Time.deltaTime;  // Time.deltaTime es el tiempo que a pasado desde el ultimo renderisado 
        if (tiempoPartida <= 0 && partidaEnCurso)
        {
            if (puntosEquipoAliado < puntosEquipoEnemigo) {
                Debug.Log("Gano el equipo de los duendes");
            }
            else {
                if (puntosEquipoAliado > puntosEquipoEnemigo)
                {
                    Debug.Log("Gano el equipo de la familia");
                }
                else {
                    Debug.Log("Empate");
                }
            }
            partidaEnCurso = false;
        }
    }
    public static void setPuntosEquipoAliado(int puntosAliado) {
        puntosEquipoAliado = puntosAliado;
    }
    public static void setPuntosEquipoEnemigo(int puntosEnemigos)
    {
        puntosEquipoEnemigo = puntosEnemigos;
    }
    public static void setTiempoPartida(int tiemPart)
    {
        tiempoPartida = tiemPart;
    }
    public static int getPuntosEquipoAliado() {
        return puntosEquipoAliado;
    }
    public static int getPuntosEquipoEnemigo()
    {
        return puntosEquipoEnemigo;
    }
    public static float getTiempoPartida()
    {
        return tiempoPartida;
    }

}
