using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
<<<<<<< Updated upstream

public class PlayerMovement : MonoBehaviour
{
    
=======
using DragonBones;

public class PlayerMovement : MonoBehaviour
{
>>>>>>> Stashed changes
    public GameObject gameOverText, restartButton;
    float dirX;
    [SerializeField]
    float moveSpeed = 5f;
    Rigidbody2D rb;
    public float JumpForce = 1;
<<<<<<< Updated upstream
    Rigidbody2D rigidBody;
    AudioSource audioSrc;
    bool isMoving = false;

    private DialogueRunner dialogueRunner = null;

=======
    AudioSource audioSrc;
    bool isMoving = false;
    bool isJump = false;
    private UnityArmatureComponent player;

    private DialogueRunner dialogueRunner = null;
>>>>>>> Stashed changes
    // Start is called before the first frame update
    void Start()
    {
        gameOverText.SetActive (false);
        restartButton.SetActive (false);
<<<<<<< Updated upstream

        rigidBody = GetComponent<Rigidbody2D>();
        audioSrc = GetComponent<AudioSource> ();

        dialogueRunner = FindObjectOfType<DialogueRunner>();
=======
        rb = GetComponent<Rigidbody2D>();
        audioSrc = GetComponent<AudioSource> ();
        dialogueRunner = FindObjectOfType<DialogueRunner>();
        player = GetComponent<UnityArmatureComponent>();
        player.animation.Play(("idle"));
>>>>>>> Stashed changes
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< Updated upstream
        
        if(dialogueRunner.IsDialogueRunning == true)
            return;
        
=======
        if(dialogueRunner.IsDialogueRunning == true)
            return;

        dirX = Input.GetAxis ("Horizontal") * moveSpeed;

>>>>>>> Stashed changes
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
            player.animation.FadeIn(("run"), 0.10f, 1);
        }
        else if (isMoving)
        {     
            if (!audioSrc.isPlaying)  
            audioSrc.Stop ();
             player.animation.Stop(("run"));
            player.animation.Play(("idle"));   
        }

        if (!Mathf.Approximately(0, movement))
       //AudioPlayer.Instance.PlaySFX ("6. footstep_single_boys_sneaker_wood_001_50917");
        transform.rotation = movement < 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
<<<<<<< Updated upstream
                
        if (isMoving) {
            if (!audioSrc.isPlaying)
            audioSrc.Play ();
        }
        else
        {   
            audioSrc.Stop ();

        }

        if (Input.GetButtonDown("Jump") && Mathf.Abs(rigidBody.velocity.y) < 0.001f)
=======
        
        
        
        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            player.animation.FadeIn(("jump"), 0.25f, 1);
        }   
        else if (Input.GetButtonUp("Jump")  && Mathf.Abs(rb.velocity.y) > 0.001f)
>>>>>>> Stashed changes
        {
            player.animation.Play(("idle"));
        }
        
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2 (dirX, rb.velocity.y);
    }

    
}
