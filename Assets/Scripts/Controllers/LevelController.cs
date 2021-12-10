using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public static LevelController instance = null;
    GameObject levelSign, gameOverText, levelCompleteText;
    int sceneIndex, levelPassed;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy (gameObject);

        levelSign = GameObject.Find ("LevelNumber");
        gameOverText = GameObject.Find ("GameOverText");
        levelCompleteText = GameObject.Find ("LevelCompleteText");
        gameOverText.gameObject.SetActive (false);
        levelCompleteText.gameObject.SetActive (false);

        sceneIndex = SceneManager.GetActiveScene ().buildIndex;
        levelPassed = PlayerPrefs.GetInt ("LevelPassed");
    }

    public void youWin()
    {
        if (sceneIndex == 3)
            Invoke ("loadMainMenu", 1f);
        else 
        {
            if (levelPassed < sceneIndex)
                PlayerPrefs.SetInt ("LevelPassed", sceneIndex);
            levelSign.gameObject.SetActive (false);
            levelCompleteText.gameObject.SetActive (true);
            Invoke ("loadNextLevel", 1f);
        }
    }

    public void youLose()
    {
        levelSign.gameObject.SetActive (false);
        gameOverText.gameObject.SetActive (true);
        Invoke ("loadMainMenu", 1f);
    }

    void loadNextLevel()
    {
        SceneManager.LoadScene (sceneIndex + 1);
    }

    void loadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
