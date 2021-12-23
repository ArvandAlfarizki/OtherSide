﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterDoor : MonoBehaviour
{
    private bool enterAllowed;
    private string sceneToLoad;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Door1>())
        {
            sceneToLoad = "Stage1";
            enterAllowed = true;
        }
        else if (collision.GetComponent<Door3>())
        {
            sceneToLoad = "Stage2";
            enterAllowed = true;
        }
        else if (collision.GetComponent<Door5>())
        {
            sceneToLoad = "Stage3";
            enterAllowed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Door1>() || collision.GetComponent<Door3>() || collision.GetComponent<Door5>())
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
