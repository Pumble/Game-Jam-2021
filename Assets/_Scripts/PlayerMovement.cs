using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    private bool tieneBandera = false;
    public float vida = 100f;

    private Animator animator;
    public List<string> animations = new List<string>();
    public static AudioSource sound;
    public List<AudioClip> audios = new List<AudioClip>();

    private bool reproducirSonidoPaso = true;



    Vector2 movement;

    // Update is called once per frame

    void Start()
    {
        animator = GetComponent<Animator>();
        sound = GetComponent<AudioSource>();
    }
    void Update()
    {
        // INPUT
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        // MOVEMENT
        if (GameManager.partidaEnCurso) {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
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
