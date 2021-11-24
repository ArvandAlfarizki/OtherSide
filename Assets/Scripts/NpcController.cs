using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcController : MonoBehaviour
{
    public bool isAccept;
    //public Animator animator;
    // Start is called before the first frame update
    public void Accept()
    {
        if(!isAccept)
        {
            isAccept = true;
            Debug.Log("Accepted");
            //animator.SetBool("Accept", isAccept);
        }
    }
}
