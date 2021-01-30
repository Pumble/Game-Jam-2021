using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    private bool tieneBandera = false;
    public float vida = 100f;

    public Animator animator;
    public List<string> animations = new List<string>();
    static AudioSource sound;
    public List<AudioClip> audios = new List<AudioClip>();


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
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
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
}
