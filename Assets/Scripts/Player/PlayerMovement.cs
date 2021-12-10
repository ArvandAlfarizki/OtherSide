using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public GameObject gameOverText, restartButton;
    public float MovementSpeed = 1;
    public float JumpForce = 1;
    private Rigidbody2D rigidBody;
    // Start is called before the first frame update
    private void Start()
    {
        gameOverText.SetActive (false);
        restartButton.SetActive (false);

        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;

        if (!Mathf.Approximately(0, movement))
        transform.rotation = movement < 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;

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
