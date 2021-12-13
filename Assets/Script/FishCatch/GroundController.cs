using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = -0.003f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(this.moveSpeed, 0, 0);
        if (transform.position.x < -20.0f)
        {
            Destroy(gameObject);
        }
    }
}
