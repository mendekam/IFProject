using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YantoMove2d : MonoBehaviour
{
    public float moveSpeed = 5f;
    bool facingRight = true;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        FlipPlayer();
        FlipTrigger();
        Jump();
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;
    }

    void Jump(){
        if (Input.GetButtonDown("Jump")){
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);

        }
    }
    
    void FlipTrigger(){
        if(transform.position < 0 && facingRight){
            FlipPlayer();
        }else if(transform.position > 0 && !facingRight){
            FlipPlayer();
        }
    }
    
    void FlipPlayer(){
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}
