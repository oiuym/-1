using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballControl : MonoBehaviour
{

    void Update()
    {
        transform.Translate(0, -0.1f, 0);
        
        if(transform.position.y < -5)
        {
            Destroy(gameObject);
        }
    }
}
