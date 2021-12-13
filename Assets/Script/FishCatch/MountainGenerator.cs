using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountainGenerator : MonoBehaviour
{
    public GameObject MountainPrefab;

    float span1 = 6.0f; //생성 주기
    float delta = 3.0f; //생성 주기 계산하기 위한 딜타임 초기값

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.span1)
        {
            this.delta = 0;
            Instantiate(MountainPrefab);
        }
    }
}
