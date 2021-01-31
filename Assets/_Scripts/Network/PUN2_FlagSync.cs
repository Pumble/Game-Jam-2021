using UnityEngine;
// USING AGREGADOS
using Photon.Pun;

namespace Pun2Demo
{
    public class PUN2_FlagSync : MonoBehaviourPun, IPunObservable
    {
        Vector3 lastestPosition;

        // Update is called once per frame
        void Update()
        {
            if (lastestPosition != transform.position)
            {
                transform.right = transform.position - lastestPosition;
                lastestPosition = transform.position;
            }
        }

        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            if (stream.IsWriting)
            {
                //We own this player: send the others our data
                stream.SendNext(transform.position);
            }
            else
            {
                //Network player, receive data
                lastestPosition = (Vector3)stream.ReceiveNext();
            }
        }
    }
}