using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class MovementStage2 : MonoBehaviour
{
    public GameObject gameOverText, restartButton;
	private Rigidbody2D rb;
	private Animator anim;
    public GameObject Trap;
    public GameObject Bucket;
    public GameObject bucketed;
	private float moveSpeed;
	private float dirX;
	private bool facingRight = true;
	private Vector3 localScale;
	AudioSource audioSrc;
	bool isMoving = false;
    bool isJump = false;
	private DialogueRunner dialogueRunner = null;
    
    private void Start()
    {
        gameOverText.SetActive (false);
        restartButton.SetActive (false);

        Trap.gameObject.SetActive (false);
        Bucket.gameObject.SetActive (false);
        bucketed.gameObject.SetActive (true);

		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		audioSrc = GetComponent<AudioSource> ();
		localScale = transform.localScale;
		moveSpeed = 5f;
		dialogueRunner = FindObjectOfType<DialogueRunner>();
	}

    // Update is called once per frame
    private void Update()
    {
		if(dialogueRunner.IsDialogueRunning == true)
            return;
			
        dirX = Input.GetAxisRaw("Horizontal") * moveSpeed;

		if (Input.GetButtonDown("Jump") && rb.velocity.y == 0)
			rb.AddForce(Vector2.up * 700f);

		if (Mathf.Abs(dirX) > 0 && rb.velocity.y == 0) {
			if (!audioSrc.isPlaying)
            audioSrc.Play ();
			anim.SetBool("isRunning", true);
		}
		else
			anim.SetBool("isRunning", false);

		if (rb.velocity.y == 0)
		{
			anim.SetBool("isJumping", false);
			anim.SetBool("isFalling", false);
		}

		if (rb.velocity.y > 0)
			anim.SetBool("isJumping", true);

		if (rb.velocity.y < 0)
		{
			anim.SetBool("isJumping", false);
			anim.SetBool("isFalling", true);
		}
    }

	private void FixedUpdate()
	{
		rb.velocity = new Vector2(dirX, rb.velocity.y);
	}

	private void LateUpdate()
	{
		if (dirX > 0)
			facingRight = true;
		else if (dirX < 0)
			facingRight = false;

		if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
			localScale.x *= -1;

		transform.localScale = localScale;
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
