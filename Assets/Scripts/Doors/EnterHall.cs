using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnterHall : MonoBehaviour
{
    private bool enterAllowed;
    private string sceneToLoad;
    public GameObject DoorText;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Door0>())
        {
            DoorText.SetActive (true);
            AudioPlayer.Instance.PlaySFX ("16. Unlock");
            sceneToLoad = "Lorong";
            enterAllowed = true;
        }
        else if (collision.GetComponent<Door2>())
        {
            DoorText.SetActive (true);
            AudioPlayer.Instance.PlaySFX ("16. Unlock");
            sceneToLoad = "Lorong2";
            enterAllowed = true;
        }else if (collision.GetComponent<Door4>())
        {
            DoorText.SetActive (true);
            AudioPlayer.Instance.PlaySFX ("16. Unlock");
            sceneToLoad = "Lorong3";
            enterAllowed = true;
        }else if (collision.GetComponent<Door6>())
        {
            DoorText.SetActive (true);
            sceneToLoad = "EndScene";
            enterAllowed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Door0>() || collision.GetComponent<Door2>() || collision.GetComponent<Door4>() || collision.GetComponent<Door6>())
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
