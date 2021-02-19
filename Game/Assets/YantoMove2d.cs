using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YantoMove2d : MonoBehaviour
{
    public float JumpForce;
    public float DownForce;
    public float speed;
    public bool isGrounded = false;
    Rigidbody2D rb;

    bool facingRight = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerJump();
        FlipTrigger();
    }

    private void FixedUpdate(){
        PlayerMovement();
    }

    void PlayerMovement(){
        float x = Input.GetAxisRaw("Horizontal");
        Vector3 movement = new Vector3(x * speed, rb.velocity.y, 0f);
        rb.velocity = movement;
    }

    void FlipTrigger(){
        if(rb.velocity.x < 0 && facingRight){
            FlipPlayer();
        }else if(rb.velocity.x > 0 && !facingRight){
            FlipPlayer();
        }
    }

    void FlipPlayer(){
        facingRight = !facingRight;

        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    void PlayerJump(){
        if(Input.GetKeyDown(KeyCode.UpArrow) && isGrounded == true){
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);
        }else if(Input.GetKeyDown(KeyCode.DownArrow)){
            rb.velocity = new Vector2(rb.velocity.x, DownForce * -1);
        }
    }
}
