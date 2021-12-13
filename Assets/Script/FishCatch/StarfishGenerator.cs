using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarfishGenerator : MonoBehaviour
{
    public GameObject starfishPrefab;

    float span1 = 1.5f; //생성 주기
    float delta = 0; //생성 주기 계산하기 위한 딜타임 초기값
    float startDelay = 2.5f; //바구니 던지는 시간 기다리기

    public void SetStarfishParameter(float span1, float delta) //다른 스크립트에서 접근할 수 있도록 public정의해두기
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
        if (this.delta > this.span1 + this.startDelay)
        {
            this.delta = this.startDelay;

            GameObject everyFish = Instantiate(starfishPrefab) as GameObject;
            float x = Random.Range(0, 2); //생성 범위
            everyFish.transform.position = new Vector2(x, 6);
        }
    }
}
