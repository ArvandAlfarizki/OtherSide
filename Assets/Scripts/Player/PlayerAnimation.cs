using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
	}
}
