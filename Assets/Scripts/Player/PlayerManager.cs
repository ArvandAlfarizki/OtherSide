using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int keyCount;

    public void PickUpKey()
    {
        keyCount++;
        Debug.Log("Picked up key");
    }

    public void UseKey()
    {
        keyCount--;
        Debug.Log("Used a key");
    }
}
