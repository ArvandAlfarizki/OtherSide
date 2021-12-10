using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseController : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D col)
    {
        LevelController.instance.youLose ();
    }
}
