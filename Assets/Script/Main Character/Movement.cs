using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 15f;
    private Rigidbody2D rb;
    public float jumpHeight = 5f;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask groundLayer;
    private BoxCollider2D coll;
    private animationManeger animManiger;
    public bool isRuning = false;

    private void Start()
    {
        coll = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        animManiger = GetComponentInChildren<animationManeger>();
    }

    private void Update()
    {
        isRuning = GroundCheck() ? true : false;
       Running();
       if(Input.GetButtonDown("Jump") && GroundCheck())
        {
            animManiger.animations(2);
            Jumping();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            animManiger.animations(1);
        }
        Slide(animManiger.isSlide);
    }

    public void Running()
    {
        rb.velocity = new Vector2(moveSpeed * Time.fixedDeltaTime, rb.velocity.y);
    }

    public void Jumping()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpHeight * Time.fixedDeltaTime);
    }

    public void Slide(bool _isSlide)
    {
        //Add particles later
        //Add Animation
        if (_isSlide)
        {
            coll.size = new Vector2(2.6f, 1f);
            coll.offset = new Vector2(-1.3f, -2.2f);
        }
        else
        {
            coll.size = new Vector2(1.7f, 2.6f);
            coll.offset = new Vector2(0.15f, -1.4f);
        }

    }

    public bool GroundCheck()
    {
        return Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);

    }

   
}
