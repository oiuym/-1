using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject player;

    void Start()
    {
        this.player = GameObject.Find("penguin");
    }

    void Update()
    {
        if (this.player.transform.position.y >= -20)
        {
            Vector3 playerPos = this.player.transform.position;
            transform.position = new Vector3(
                playerPos.x, playerPos.y, transform.position.z);
        }
        
    }
}
