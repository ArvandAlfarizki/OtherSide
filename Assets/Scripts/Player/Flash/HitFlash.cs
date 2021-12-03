using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitFlash : MonoBehaviour
{
    public float destroyTime, damage;
    public GameObject hitEfect;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Timer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;

        if(collisionGameObject.name != "Player")
        {
            if(collisionGameObject.GetComponent<HealthEnemy>() !=null)
            {
                collisionGameObject.GetComponent<HealthEnemy>().TakeDamage(damage);
            }
            Destroy();
        }
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(destroyTime);
        Destroy();
    }

    void Destroy()
    {
        if(hitEfect !=null)
        {
            Instantiate(hitEfect, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }
}
