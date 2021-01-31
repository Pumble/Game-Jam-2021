using UnityEngine;
// USING AGREGADOS
using Photon.Pun;

namespace Pun2Demo
{
    public class PUN2_BullerSync : MonoBehaviourPun, IPunObservable
    {
        Vector3 lastesPosition;
        Quaternion lastestRotation;

        Projectile projectile;

        private void Awake()
        {
            projectile = GetComponent<Projectile>();
        }

        // Update is called once per frame
        void Update()
        {
            //Update remote player (smooth this, this looks good, at the cost of some accuracy)
            transform.position = Vector3.Lerp(transform.position, lastesPosition, projectile.velocity);
            transform.rotation = Quaternion.Lerp(transform.rotation, lastestRotation, Tprojectile.velocity);
        }

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
                lastesPosition = (Vector3)stream.ReceiveNext();
                lastestRotation = (Quaternion)stream.ReceiveNext();
            }
        }
    }
}