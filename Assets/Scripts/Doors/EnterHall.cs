using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterHall : MonoBehaviour
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
        else if (collision.GetComponent<Door2>())
        {
            sceneToLoad = "Lorong2";
            enterAllowed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Door0>() || collision.GetComponent<Door2>())
        {
            enterAllowed = false;
        }
    }

    private void Update()
    {
        if (enterAllowed && Input.GetKey(KeyCode.DownArrow))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
