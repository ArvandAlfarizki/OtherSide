using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementStage2 : MonoBehaviour
{
    public GameObject gameOverText, restartButton;
    public GameObject Trap;
    public GameObject Bucket;
    public GameObject bucketed;
    float dirX;
    [SerializeField]
    float moveSpeed = 5f;
    Rigidbody2D rb;
    public float JumpForce = 1;
    AudioSource audioSrc;
    bool isMoving = false;
    bool isJump = false;
    
    

    // Start is called before the first frame update
    private void Start()
    {
        gameOverText.SetActive (false);
        restartButton.SetActive (false);
        Trap.gameObject.SetActive (false);
        Bucket.gameObject.SetActive (false);
        bucketed.gameObject.SetActive (true);

        rb = GetComponent<Rigidbody2D>();
        audioSrc = GetComponent<AudioSource> ();
        
        
    }

    // Update is called once per frame
    private void Update()
    {

        dirX = Input.GetAxis ("Horizontal") * moveSpeed;

        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * moveSpeed;

        //if (isMoving)
        //{
            //player.animation.FadeIn(("run"), 0.25f, 1);
        //}
        //else{
            //player.animation.Play(("idle"));
        //}
    
        if (rb.velocity.x != 0){
        isMoving = true;
        }
        else{
        isMoving = false;
        }

        if (isMoving) {
            if (!audioSrc.isPlaying)
            audioSrc.Play ();
            
        }
        else if (isMoving)
        {     
            if (!audioSrc.isPlaying)  
            audioSrc.Stop ();
              
        }

        if (!Mathf.Approximately(0, movement))
       //AudioPlayer.Instance.PlaySFX ("6. footstep_single_boys_sneaker_wood_001_50917");
        transform.rotation = movement < 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
        
        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2 (dirX, rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Trap.gameObject.SetActive(true);
        Bucket.gameObject.SetActive(true);
        bucketed.gameObject.SetActive(false);
    }

    void OnCollisionEnter2D (Collision2D col)
    {
        if (col.gameObject.tag.Equals ("Enemy"))
        {
        gameOverText.SetActive (true);
        restartButton.SetActive (true);
        gameObject.SetActive (false);
        }
    }
}
