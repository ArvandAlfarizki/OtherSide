using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject panelpause;

    public void pauseControl()
    {
        if (Time.timeScale == 1){
            panelpause.SetActive (true);
            Time.timeScale = 0;
        } else {
            Time.timeScale = 1;
            panelpause.SetActive (false);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene (SceneManager.GetActiveScene() .buildIndex);
        Time.timeScale = 1;
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
}
