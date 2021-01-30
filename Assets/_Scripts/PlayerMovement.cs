using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// USING AGREGADOS
using Photon.Pun;

namespace Pun2Demo
{
    public class PlayerMovement : MonoBehaviourPun, IPunObservable
    {
        public float moveSpeed = 5f;
        public Rigidbody2D rb;

        // Vector2 movement;
        float HorizontalInput = 0.0f;
        float VerticalInput = 0.0f;

        private bool tieneBandera = false;
        public float vida = 100f;

        private Animator animator;
        private List<string> animations = new List<string>();
        private AudioSource sound;
        private List<AudioClip> audios = new List<AudioClip>();

        #region INTERFAZ

        bool valuesReceived = false;

        #endregion

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            if (photonView.IsMine)
            {
                // INPUT
                HorizontalInput = Input.GetAxisRaw("Horizontal");
                VerticalInput = Input.GetAxisRaw("Vertical");

                Debug.Log("x: " + HorizontalInput);
                Debug.Log("y: " + VerticalInput);
            }
        }

        private void FixedUpdate()
        {
            // MOVEMENT
            Vector2 movement = new Vector2(HorizontalInput, VerticalInput);
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

            animator.SetFloat("Horizontal", HorizontalInput);
            animator.SetFloat("Vertical", VerticalInput);
            if (tieneBandera)
            {
                GameObject.Find("Bandera").GetComponent<Rigidbody2D>().MovePosition(new Vector2(rb.position.x + 2f, rb.position.y + 2f) + movement * moveSpeed * Time.fixedDeltaTime);
            }
        }

        public void setTieneBandera(bool tienBand)
        {
            tieneBandera = tienBand;
        }

        public bool getTieneBandera()
        {
            return tieneBandera;
        }

        #region INTERFAZ

        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            if (stream.IsWriting)
            {
                //We own this player: send the others our data
                stream.SendNext(HorizontalInput);
                stream.SendNext(VerticalInput);
            }
            else if (!photonView.IsMine)
            {
                //Network player, receive data
                HorizontalInput = (float)stream.ReceiveNext();
                VerticalInput = (float)stream.ReceiveNext();
            }
            valuesReceived = true;
        }
    }

    #endregion
}