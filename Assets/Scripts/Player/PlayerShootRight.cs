using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class PlayerShootRight : MonoBehaviour
{
    public float shootSpeed, shootTimer;
    private bool isShooting;

    public Transform shootPos;
    public GameObject flashHit;
    private DialogueRunner dialogueRunner = null;
    // Start is called before the first frame update
    void Start()
    {
        isShooting = false;
        dialogueRunner = FindObjectOfType<DialogueRunner>();
    }

    // Update is called once per frame
    void Update()
    {
        if(dialogueRunner.IsDialogueRunning == true)
            return;
            
        if (Input.GetButtonDown("Fire1") && !isShooting)
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        int direction()
        {
            AudioPlayer.Instance.PlaySFX ("18. Water");
            if(transform.localScale.x < 0f)
            {
                return -1;
            }
            else
            {
                return +1;
            }
        }

        isShooting = true;
        GameObject newFlash = Instantiate(flashHit, shootPos.position, Quaternion.identity);
        newFlash.GetComponent<Rigidbody2D>().velocity = new Vector2(shootSpeed * direction() * Time.fixedDeltaTime, 0f);
        newFlash.transform.localScale = new Vector2(newFlash.transform.localScale.x * direction(), newFlash.transform.localScale.y);
        yield return new WaitForSeconds(shootTimer);
        isShooting = false;
    }
}
