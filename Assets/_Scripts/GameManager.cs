using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static int puntosEquipoAliado;
    private static int puntosEquipoEnemigo;
    private static float tiempoPartida;


    void Start()
    {
        puntosEquipoAliado = 0;
        puntosEquipoEnemigo = 0;
        tiempoPartida = 300;

    }

    // Update is called once per frame
    void Update()
    {
        
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
