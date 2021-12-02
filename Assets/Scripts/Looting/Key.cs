using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour
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
