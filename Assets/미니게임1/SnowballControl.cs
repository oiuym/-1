using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballControl : MonoBehaviour
{
    GameObject player;
    GameObject hpControl;

    void Start()
    {
        player = GameObject.Find("Player");
        hpControl = GameObject.Find("HPControl");
    }

    void Update()
    {
        transform.Translate(0, -0.03f, 0);
        
        if(transform.position.y < -5)
        {
            Destroy(gameObject);
        }

        Vector2 p1 = transform.position;
        Vector2 p2 = player.transform.position;
        Vector2 direction = p1 - p2;
        float distance = direction.magnitude;
        float r1 = 0.3f;
        float r2 = 0.7f;

        if (distance < r1+r2)
        {
            Debug.Log("충돌");
            Destroy(gameObject);
            hpControl.GetComponent<HPControl>().HPDecrease();
        }
    }
}
