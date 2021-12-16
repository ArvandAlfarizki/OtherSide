using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float walkspeed;
    public Rigidbody2D rb;
    public float JumpForce = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float direction = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(walkspeed * direction * Time.fixedDeltaTime, rb.velocity.y);
    
        if (direction != 0f)
        {
            transform.localScale = new Vector2 (Mathf.Abs(transform.localScale.x) * direction, transform.localScale.y);
        }

        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }
    }
}
