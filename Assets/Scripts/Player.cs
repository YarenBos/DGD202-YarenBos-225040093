using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D rb;

    public float jumpForce;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayers;
    private bool isGrounded;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        anim=GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayers);

        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            AudioManager.instance.PlaySFX(2);
        }

        anim.SetBool("OnGround",isGrounded);

    }
}
