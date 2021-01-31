using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// USING AGREGADOS
using Photon.Pun;

namespace Pun2Demo
{
    public enum CharacterOptions : int { kid = 0, mom = 1, dad = 2, geko = 3, rat = 4, cockroach = 5 };

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

        private bool tieneBandera = false;
        [Header("Cantidad de salud del personaje")]
        public float vida = 100f;

        private Animator animator;
        private AudioSource sound;
        private List<AudioClip> audios = new List<AudioClip>();
        private bool reproducirSonidoPaso = true;

        [Header("Lista de personajes disponibles para jugar, establece el tipo del prefab")]
        public CharacterOptions characterType;

        #endregion

        private void Awake()
        {
            animator = GetComponent<Animator>();
            sound = GetComponent<AudioSource>();
        }

        // Update is called once per frame
        void Update()
        {
            if (photonView.IsMine)
            {
                // INPUT
                HorizontalInput = Input.GetAxisRaw("Horizontal");
                VerticalInput = Input.GetAxisRaw("Vertical");
            }
        }

        private void FixedUpdate()
        {
            if (GameManager.partidaEnCurso)
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
                if (reproducirSonidoPaso)
                {
                    sound.PlayOneShot(audios[0]);
                    reproducirSonidoPaso = false;

                    StartCoroutine("corrutinaReproducirPaso");
                }
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

        IEnumerator corrutinaReproducirPaso()
        {
            yield return new WaitForSeconds((float)0.1);
            reproducirSonidoPaso = true;
        }
    }
}