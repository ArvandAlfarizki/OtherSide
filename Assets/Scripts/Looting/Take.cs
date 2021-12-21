using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Take : MonoBehaviour
{
    public bool PickUp;

    public void Pick()
    {
        if(!PickUp)
        {
            PickUp = true;
            Debug.Log("Key Picked");
            Destroy(gameObject);
        }
    }
}
