using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinController : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D col)
    {
        LevelController.instance.youWin ();
    }
}
