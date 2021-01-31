using UnityEngine;
// USING AGREGADOS
using Photon.Pun;

namespace Pun2Demo
{
    public class PUN2_FlagSync : MonoBehaviourPun, IPunObservable
    {
        Vector3 latestPos;

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
                latestPos = (Vector3)stream.ReceiveNext();
            }
        }

        // Update is called once per frame
        void Update()
        {
            //Update remote player (smooth this, this looks good, at the cost of some accuracy)
            transform.position = Vector3.Lerp(transform.position, latestPos, Time.deltaTime * 2);
        }
    }
}