using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// USING AGREGADOS
using Photon.Pun;

namespace Pun2Demo
{
    public class ChanclaController : MonoBehaviourPun, IPunObservable
    {
        public int Damage = 35;
        public PlayerMovement Player;

        Vector3 latestPos;
        Quaternion latestRot;

        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            if (stream.IsWriting)
            {
                //We own this player: send the others our data
                stream.SendNext(transform.position);
                stream.SendNext(transform.rotation);
            }
            else
            {
                //Network player, receive data
                latestPos = (Vector3)stream.ReceiveNext();
                latestRot = (Quaternion)stream.ReceiveNext();
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (!photonView.IsMine)
            {
                //Update remote player (smooth this, this looks good, at the cost of some accuracy)
                transform.position = Vector3.Lerp(transform.position, latestPos, Time.deltaTime * 5);
                transform.rotation = Quaternion.Lerp(transform.rotation, latestRot, Time.deltaTime * 5);
            }
        }
    }
}