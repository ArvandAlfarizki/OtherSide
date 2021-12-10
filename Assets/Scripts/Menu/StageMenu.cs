using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageMenu : MonoBehaviour
{

    public Button Level2, Level3;
    int levelPassed;

    // Start is called before the first frame update
    void Start()
    {
        levelPassed = PlayerPrefs.GetInt ("LevelPassed");
        Level2.interactable = false;
        Level3.interactable = false;

        switch (levelPassed)
        {
            case 1:
            Level2.interactable = true;
            break;
            case 2:
            Level2.interactable = true;
            Level3.interactable = true;
            break;
        }
    }

    public void levelToLoad (int level)
    {
        SceneManager.LoadScene (level);
    }

    public void resetPlayerPrefs()
    {
        Level2.interactable = false;
        Level3.interactable = false;
        PlayerPrefs.DeleteAll ();
    }

    public void Back()
    {
        SceneManager.LoadScene(0);
        
    }
}
