﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Player, transform.position, Quaternion.identity);
    }
}
