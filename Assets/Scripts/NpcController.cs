using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NpcController : MonoBehaviour
{
    public bool isAccept;
    [SerializeField]
    private Text pickupText;
    //public Animator animator;
    // Start is called before the first frame update
    private void Start()
    {
        pickupText.gameObject.SetActive(false);
    }
    public void Accept()
    {
        if(!isAccept)
        {
            isAccept = true;
            Debug.Log("Accepted");
            //animator.SetBool("Accept", isAccept);
            pickupText.gameObject.SetActive(true);
        }
    }
}
