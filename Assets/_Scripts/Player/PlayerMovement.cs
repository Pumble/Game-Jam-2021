using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// USING AGREGADOS
using Photon.Pun;

namespace Pun2Demo
{
    public class PlayerMovement : MonoBehaviourPun
    {
        #region VARS

        [Header("Establece la velocidad de movimiento del personaje")]
        public float moveSpeed = 5f;
        [Header("Rigibbody2D asociado al personaje")]
        public Rigidbody2D rb;

        // Vector2 movement;
        float HorizontalInput = 0.0f;
        float VerticalInput = 0.0f;

        private Animator animator;
        public AudioSource sound;
        public List<AudioClip> audios = new List<AudioClip>();
        private bool reproducirSonidoPaso = true;
        public List<KeyCode> keys = new List<KeyCode>();

        private Player _player;

        #endregion

        private void Awake()
        {
            animator = GetComponent<Animator>();
            sound = GetComponent<AudioSource>();
            _player = GetComponent<Player>();
        }

        // Update is called once per frame
        void Update()
        {
            if (photonView.IsMine)
            {
                HorizontalInput = Input.GetAxisRaw("Horizontal");
                VerticalInput = Input.GetAxisRaw("Vertical");
            }
        }

        private void FixedUpdate()
        {
            if (GameManager.partidaEnCurso && _player.vida > 0)
            {
                // MOVEMENT
                Vector2 movement = new Vector2(HorizontalInput, VerticalInput);
                rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

                animator.SetFloat("Horizontal", HorizontalInput);
                animator.SetFloat("Vertical", VerticalInput);
                if (_player.tieneBandera)
                {
                    GameObject.Find("Flag").GetComponent<Rigidbody2D>().MovePosition(new Vector2(rb.position.x + 2f, rb.position.y + 2f) + movement * moveSpeed * Time.fixedDeltaTime);
                }
                if (reproducirSonidoPaso && (audios.Count > 0) && (Input.GetKey(keys[0]) || Input.GetKey(keys[1]) || Input.GetKey(keys[2]) || Input.GetKey(keys[3])) )
                {
                    sound.PlayOneShot(audios[0]);
                    reproducirSonidoPaso = false;

                    StartCoroutine("corrutinaReproducirPaso");
                }
            }
        }

        IEnumerator corrutinaReproducirPaso()
        {
            yield return new WaitForSeconds((float)0.4);
            reproducirSonidoPaso = true;
        }

        #region DEBUG

        void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireCube(transform.position, new Vector3(1, 1, 1));
        }

        #endregion
    }
}