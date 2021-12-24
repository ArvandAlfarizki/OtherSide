using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlash : MonoBehaviour
{
    public float shootSpeed, shootTimer;
    private bool isShooting;

    public Transform shootPos;
    public GameObject flashHit;
    // Start is called before the first frame update
    void Start()
    {
        isShooting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !isShooting)
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        int direction()
        {
            if(transform.localScale.x > 0f)
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
