using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    float vertical, horizontal;
    bool isFacingRight = true;
    Rigidbody2D rb;
    Animator animator;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        Flip();
        animator.SetFloat("Horizontal", Mathf.Abs(horizontal));
        animator.SetFloat("Vertical", Mathf.Abs(vertical));
    }

    private void FixedUpdate() {
        rb.velocity = new Vector2(horizontal * speed, vertical * speed);
    }

    void Flip()
    {
        if(isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
