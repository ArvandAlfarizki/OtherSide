using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelNumber : MonoBehaviour
{
    Text text;
    int sceneIndex;
    
    void Start()
    {
        text = GetComponent<Text> ();
        sceneIndex = SceneManager.GetActiveScene ().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Level " + sceneIndex;
    }
}
