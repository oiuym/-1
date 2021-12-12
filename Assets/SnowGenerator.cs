using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowGenerator : MonoBehaviour
{
    public GameObject arrowPrefab;
    float span = 0.15f;
    float delta = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        delta += Time.deltaTime;
        if (delta > span)
        {
            GameObject go = Instantiate(arrowPrefab) as GameObject;
            go.transform.position = new Vector3(Random.Range(-6, 6), 6, 0);
            delta = 0;
        }

    }
}
