using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Game Manager del nivel")]
    private static int puntosEquipoAliado;
    private static int puntosEquipoEnemigo;
    private static float tiempoPartida;
    public static bool partidaEnCurso;

    void Start()
    {
        puntosEquipoAliado = 0;
        puntosEquipoEnemigo = 0;
        tiempoPartida = 300;
    }

    #region SETTERS

    public static void setPuntosEquipoAliado(int puntosAliado)
    {
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

    #endregion

    #region GETTERS

    public static int getPuntosEquipoAliado()
    {
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

    #endregion
}
