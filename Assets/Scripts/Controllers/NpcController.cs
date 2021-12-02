using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NpcController : MonoBehaviour
{
    public bool isAccept;
    [SerializeField]
    private GameObject Key;
    [SerializeField]
    private GameObject doorOut;
    //public Animator animator;
    // Start is called before the first frame update
    private void Start()
    {
        Key.gameObject.SetActive(false);
        doorOut.gameObject.SetActive(false);
    }
    
    public void Accepted(GameObject obj)
    {
        if(!isAccept)
        {
            PlayerManager manager = obj.GetComponent<PlayerManager>();
            if(manager)
            {
                if(manager.keyCount > 0)
                {
                    isAccept = true;
                    manager.UseKey();
                    Key.gameObject.SetActive(true);
                    doorOut.gameObject.SetActive(true);
                }
            }
        }
    }
}
