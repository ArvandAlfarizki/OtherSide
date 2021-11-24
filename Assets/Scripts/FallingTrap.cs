using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTrap : MonoBehaviour
{
    Rigidbody2D Rb;
    [SerializeField]
    float Speed;
    [SerializeField]
    LayerMask HeroLayer;

    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics2D.Raycast(Rb.position , Vector2.down, 10f , HeroLayer))
        {
            Rb.velocity = Vector2.down * Speed;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            collision.gameObject.GetComponent<PlayerMovement>().Death();
        }
    }
}
