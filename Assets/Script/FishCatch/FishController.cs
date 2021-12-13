using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishController : MonoBehaviour
{
    public float dropSpeed = -0.1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StaticMember.second += Time.deltaTime;

        transform.Translate(this.dropSpeed, 0, 0);
        if (transform.position.y < -5.0f)
        {
            Destroy(gameObject);
        }
    }

    
}
