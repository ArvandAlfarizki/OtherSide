using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
    public bool isOpen;

    public void OpenDoor(GameObject obj)
    {
        if(!isOpen)
        {
            PlayerManager manager = obj.GetComponent<PlayerManager>();
            if(manager)
            {
                if(manager.keyCount > 0)
                {
                    isOpen = true;
                    manager.UseKey();
                }
            }
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
