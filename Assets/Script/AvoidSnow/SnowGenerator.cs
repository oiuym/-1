using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowGenerator : MonoBehaviour
{
    public GameObject arrowPrefab;
    float span1 = 0.15f;
    float delta = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        delta += Time.deltaTime;
        if (delta > span1)
        {
            GameObject go = Instantiate(arrowPrefab) as GameObject;
            go.transform.position = new Vector3(Random.Range(-8, 9), 6, 0);
            delta = 0;
            if (span1 > 0.003)
            {
                span1 -= 0.0003f;
            }
        }

    }
}
