using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// USING AGREGADOS
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Game Manager del nivel")]
    private static int puntosEquipoAliado;
    private static int puntosEquipoEnemigo;
    private static int tiempoPartida;
    public static bool partidaEnCurso;

    public Text puntosAliados;
    public Text puntosEnemigos;
    public Text tiempoPartidaLabel;
    public GameObject winPanel;

    void Start()
    {
        puntosEquipoAliado = 0;
        puntosEquipoEnemigo = 0;
        tiempoPartida = 300;
        partidaEnCurso = true;
        InvokeRepeating("updateTime", 1f, 1f);
    }

    void updateTime()
    {
        if (partidaEnCurso)
        {
            tiempoPartida--;
            if (tiempoPartida <= 0)
            {
                partidaEnCurso = false;
            }
        }
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

    public static int getTiempoPartida()
    {
        return tiempoPartida;
    }

    #endregion

    private void LateUpdate()
    {
        // REVISAR EL QUE YA GANO
        // STATE WIN
        if (puntosEquipoAliado >= 3 || puntosEquipoEnemigo >= 3)
        {
            gameObject.SetActive(true);
        }

        if (puntosAliados)
            puntosAliados.text = puntosEquipoAliado.ToString();
        if (puntosEnemigos)
            puntosEnemigos.text = puntosEquipoEnemigo.ToString();
        if (tiempoPartidaLabel)
            tiempoPartidaLabel.text = tiempoPartida.ToString();
    }
}
