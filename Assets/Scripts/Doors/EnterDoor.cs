using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterDoor : MonoBehaviour
{
    private bool enterAllowed;
    private string sceneToLoad;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Door0>())
        {
            sceneToLoad = "Lorong";
            enterAllowed = true;
        }
        if (collision.GetComponent<Door1>())
        {
            sceneToLoad = "Stage1";
            enterAllowed = true;
        }
        else if (collision.GetComponent<Door2>())
        {
            sceneToLoad = "Lorong2";
            enterAllowed = true;
        }
        else if (collision.GetComponent<Door3>())
        {
            sceneToLoad = "Stage2";
            enterAllowed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Door0>() || collision.GetComponent<Door1>() || collision.GetComponent<Door2>() || collision.GetComponent<Door3>())
        {
            enterAllowed = false;
        }
    }

    private void Update()
    {
        if (enterAllowed && Input.GetKey(KeyCode.UpArrow))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
