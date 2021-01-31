using UnityEngine;
// USING AGREGADOS
using Photon.Pun;

namespace Pun2Demo
{
    public class PUN2_BulletSync : MonoBehaviourPun, IPunObservable
    {
        Vector3 lastesPosition;

        // Update is called once per frame
        void Update()
        {
            if (lastesPosition != transform.position)
            {
                transform.right = transform.position - lastesPosition;
                lastesPosition = transform.position;
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
                lastesPosition = (Vector3)stream.ReceiveNext();
            }
        }
    }
}