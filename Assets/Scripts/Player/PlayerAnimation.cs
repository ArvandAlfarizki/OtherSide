using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< Updated upstream
using DragonBones;

public class PlayerAnimation : MonoBehaviour
{
    public string idleAnimation = "idle";
	public string runAnimation = "run";
    public string jumpAnimation = "jump";
    public string dieAnimation = "death";

    enum State {IDLE, RUN, JUMP, DEATH};
    private State state = State.IDLE;
    private UnityArmatureComponent armatureComponent;
    // Start is called before the first frame update
    void Start()
    {
        armatureComponent = transform.GetComponentInChildren<UnityArmatureComponent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Idle() {
		if (state != State.DEATH && state != State.IDLE) {
			armatureComponent.animation.FadeIn (idleAnimation, 0.5f, -1);
			armatureComponent.animation.timeScale = 1f;
			state = State.IDLE;
		}
	}

    public void Run(float speed) {
		if (state != State.DEATH) {
			if (speed > 0 && transform.lossyScale.x > 0 || speed < 0 && transform.lossyScale.x < 0) {
				if (state != State.RUN) {
					armatureComponent.animation.FadeIn (runAnimation, 0.25f, -1);
					state = State.RUN;
				}
				armatureComponent.animation.timeScale = speed;
			} else if (speed < 0 && transform.lossyScale.x > 0 || speed > 0 && transform.lossyScale.x < 0) {
				if (state != State.RUN) {
					armatureComponent.animation.FadeIn (runAnimation, 0.25f, -1);
					state = State.RUN;
				}
				armatureComponent.animation.timeScale = -speed;
			}
		}
	}

	public void Jump() {
		if (state != State.DEATH && state != State.JUMP) {
			armatureComponent.animation.FadeIn (jumpAnimation, 0.25f, 1);
			armatureComponent.animation.timeScale = 1f;
			state = State.JUMP;
		}
	}

    public void Death() {
		if (state != State.DEATH) {
			armatureComponent.animation.Play (dieAnimation, 1);
			armatureComponent.animation.timeScale = 1f;
			state = State.DEATH;
		}
=======

public class PlayerAnimation : MonoBehaviour
{
	private Rigidbody2D rb;
	private Animator anim;
	private float moveSpeed;
	private float dirX;
	private bool facingRight = true;
	private Vector3 localScale;
    
    private void Start()
    {
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		localScale = transform.localScale;
		moveSpeed = 5f;
	}

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal") * moveSpeed;

		if (Input.GetButtonDown("Jump") && rb.velocity.y == 0)
			rb.AddForce(Vector2.up * 700f);

		if (Mathf.Abs(dirX) > 0 && rb.velocity.y == 0)
			anim.SetBool("isRunning", true);
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
>>>>>>> Stashed changes
	}
}
