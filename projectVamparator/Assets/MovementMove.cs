using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MovementClass;

namespace MovementClass
{
    public class MovementMove : MonoBehaviour
    {
        public float moveSpeed = 5f;
        public Rigidbody2D playerRigidbody;

        void FixedUpdate()
        {
            Vector2 moveDirection = MovementInput.joystickDirection * moveSpeed;
            playerRigidbody.velocity = moveDirection;
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}
