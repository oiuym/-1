using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishGenerator : MonoBehaviour
{
    public GameObject fish1Prefab; //물고기 소스 투입칸 마련
    public GameObject fish2Prefab;//물고기 소스 투입칸 마련

    float span1 = 0.3f; //생성 주기
    float delta = 0; //생성 주기 계산하기 위한 딜타임 초기값
    float startDelay = 2.0f; //바구니 던지는 시간 기다리기
    int ratio = 3; //fish2 생성 확률

    public void SetFishParameter(float span1, float delta, int ratio) //다른 스크립트에서 접근할 수 있도록 public정의해두기
    {
        this.span1 = span1;
        this.delta = delta;
        this.ratio = ratio;
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

            GameObject everyFish;
            int fishDice = Random.Range(1, 11);
            if (fishDice >= this.ratio) everyFish = Instantiate(fish1Prefab) as GameObject;
            else everyFish = Instantiate(fish2Prefab) as GameObject;

            float x = Random.Range(-4, 1); //생성 범위
            everyFish.transform.position = new Vector2(x, 6);
        }
    }
}
