using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pun2Demo
{
    public class PlayerMovement : MonoBehaviour
    {
        public float moveSpeed = 5f;
        public Rigidbody2D rb;

        Vector2 movement;

        // Update is called once per frame
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

        }
    }
}