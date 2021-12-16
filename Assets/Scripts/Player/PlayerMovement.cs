using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class PlayerMovement : MonoBehaviour
{
<<<<<<< Updated upstream

=======
    
>>>>>>> Stashed changes
    public GameObject gameOverText, restartButton;
    public float MovementSpeed = 1;
    public float JumpForce = 1;
    Rigidbody2D rigidBody;
    AudioSource audioSrc;
    bool isMoving = false;

    private DialogueRunner dialogueRunner = null;

    // Start is called before the first frame update
    private void Start()
    {
        gameOverText.SetActive (false);
        restartButton.SetActive (false);

        rigidBody = GetComponent<Rigidbody2D>();
        audioSrc = GetComponent<AudioSource> ();

        dialogueRunner = FindObjectOfType<DialogueRunner>();
    }

    // Update is called once per frame
    private void Update()
    {
        
        if(dialogueRunner.IsDialogueRunning == true)
            return;
        
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;

        if (!Mathf.Approximately(0, movement))
       //AudioPlayer.Instance.PlaySFX ("6. footstep_single_boys_sneaker_wood_001_50917");
        transform.rotation = movement < 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
                
        if (isMoving) {
            if (!audioSrc.isPlaying)
            audioSrc.Play ();
        }
        else
        {   
            audioSrc.Stop ();

        }

        if (Input.GetButtonDown("Jump") && Mathf.Abs(rigidBody.velocity.y) < 0.001f)
        {
            rigidBody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }
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
