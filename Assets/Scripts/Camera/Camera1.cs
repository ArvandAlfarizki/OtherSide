using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera1 : MonoBehaviour
{
    [SerializeField]
    private Transform targetToFollow;

    void Update()
    {
        transform.position = new Vector3(
        Mathf.Clamp(targetToFollow.position.x, 0.3f, 64.2f),
        Mathf.Clamp(targetToFollow.position.y, 0f, 0f),
        transform.position.z);    
    }
}
