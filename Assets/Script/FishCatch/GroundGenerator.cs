using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{
    public GameObject GroundPrefab;

    float span1 = 2.5f; //생성 주기
    float delta = 1.8f; //생성 주기 계산하기 위한 딜타임 초기값

    public void SetGroundParameter(float span1, float delta) //다른 스크립트에서 접근할 수 있도록 public정의해두기
    {
        this.span1 = span1;
        this.delta = delta;
    }

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
            Instantiate(GroundPrefab);
        }
    }
}
