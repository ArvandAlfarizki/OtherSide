using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementStage3 : MonoBehaviour
{
    public GameObject gameOverText, restartButton;
    public GameObject TriggerEnemy;
    public GameObject Light;
    public GameObject Lighting;
<<<<<<< Updated upstream
    public float MovementSpeed = 1;
    public float JumpForce = 1;
    private Rigidbody2D rigidBody;
    AudioSource audioSrc;
    bool isMoving = false;
=======
    float dirX;
    [SerializeField]
    float moveSpeed = 5f;
    Rigidbody2D rb;
    public float JumpForce = 1;
    AudioSource audioSrc;
    bool isMoving = false;
    bool isJump = false;
>>>>>>> Stashed changes
    

    // Start is called before the first frame update
    private void Start()
    {
        gameOverText.SetActive (false);
        restartButton.SetActive (false);
        Light.SetActive (true);
        TriggerEnemy.gameObject.SetActive (false);
        Lighting.gameObject.SetActive (false);

<<<<<<< Updated upstream
        rigidBody = GetComponent<Rigidbody2D>();
=======
        rb = GetComponent<Rigidbody2D>();
>>>>>>> Stashed changes
        audioSrc = GetComponent<AudioSource> ();
        
    }

    // Update is called once per frame
    private void Update()
    {

<<<<<<< Updated upstream
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;

        if (!Mathf.Approximately(0, movement))
        transform.rotation = movement < 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
=======
        dirX = Input.GetAxis ("Horizontal") * moveSpeed;

        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * moveSpeed;

        if (rb.velocity.x != 0){
        isMoving = true;
        }
        else{
        isMoving = false;
        }
>>>>>>> Stashed changes

        if (isMoving) {
            if (!audioSrc.isPlaying)
            audioSrc.Play ();
<<<<<<< Updated upstream
        }
        else   {
            audioSrc.Stop ();

        }
        
        if (Input.GetButtonDown("Jump") && Mathf.Abs(rigidBody.velocity.y) < 0.001f)
        {
            rigidBody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }
    }

=======
            
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

>>>>>>> Stashed changes
    private void OnTriggerEnter2D(Collider2D collider)
    {
        TriggerEnemy.gameObject.SetActive(true);
        Lighting.gameObject.SetActive(true);
        Light.gameObject.SetActive(false);
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
