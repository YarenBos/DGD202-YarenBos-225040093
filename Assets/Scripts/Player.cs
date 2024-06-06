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

    private bool canDash = true;
    private bool isDashing;
    public float dashingPower = 15f;
    public float dashingTime = 0.2f;
    public float dashingCooldown = 1.5f;
    public TrailRenderer tr;

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
        if (isDashing)
        {
            return;
        }

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayers);

        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            StartCoroutine(Dash());
        }


        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            AudioManager.instance.PlaySFX(2);
        }

        anim.SetBool("OnGround",isGrounded);

    }

    IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0;
        rb.velocity = new Vector2(dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }


}
