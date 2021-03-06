using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class Movement : MonoBehaviour
{
    float dirX;
    [SerializeField]
    float moveSpeed = 5f;
    Rigidbody2D rb;
    public float JumpForce = 1;
    AudioSource audioSrc;
    private Animator anim;
    bool isMoving = false;
    bool isJump = false;

    private DialogueRunner dialogueRunner = null;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSrc = GetComponent<AudioSource> ();
        anim = GetComponent<Animator>();
        dialogueRunner = FindObjectOfType<DialogueRunner>();
    }

    // Update is called once per frame
    void Update()
    {
        if(dialogueRunner.IsDialogueRunning == true)
            return;

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
            anim.SetBool("isRunning", true);
        }
        else if (isMoving)
        {     
            if (!audioSrc.isPlaying)  
            audioSrc.Stop ();
            anim.SetBool("isRunning", false);
        }

        if (!Mathf.Approximately(0, movement))
       //AudioPlayer.Instance.PlaySFX ("6. footstep_single_boys_sneaker_wood_001_50917");
        transform.rotation = movement < 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
        
        
        
        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            anim.SetBool("isJump", true);
        }   
        else if (Input.GetButtonUp("Jump")  && Mathf.Abs(rb.velocity.y) > 0.001f)
        {
            anim.SetBool("isJump", false);
        }
        
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2 (dirX, rb.velocity.y);
    }

    
}
