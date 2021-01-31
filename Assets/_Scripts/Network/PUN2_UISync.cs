using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// USING AGREGADOS
using Photon.Pun;

namespace Pun2Demo
{
    public class PUN2_UISync : MonoBehaviourPun, IPunObservable
    {
        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            if (stream.IsWriting)
            {
                //We own this player: send the others our data
                stream.SendNext(GameManager.getPuntosEquipoAliado());
                stream.SendNext(GameManager.getPuntosEquipoEnemigo());
                stream.SendNext(GameManager.getTiempoPartida());
                stream.SendNext(GameManager.partidaEnCurso);
            }
            else
            {
                //Network player, receive data
                GameManager.setPuntosEquipoAliado((int)stream.ReceiveNext());
                GameManager.setPuntosEquipoEnemigo((int)stream.ReceiveNext());
                GameManager.setTiempoPartida((int)stream.ReceiveNext());
                GameManager.partidaEnCurso = (bool)stream.ReceiveNext();
            }
        }
    }
}