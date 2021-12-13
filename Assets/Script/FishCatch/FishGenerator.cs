using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishGenerator : MonoBehaviour
{
    public GameObject fish1Prefab; //����� �ҽ� ����ĭ ����
    public GameObject fish2Prefab;//����� �ҽ� ����ĭ ����

    float span1 = 0.3f; //���� �ֱ�
    float delta = 0; //���� �ֱ� ����ϱ� ���� ��Ÿ�� �ʱⰪ
    float startDelay = 2.0f; //�ٱ��� ������ �ð� ��ٸ���
    int ratio = 3; //fish2 ���� Ȯ��

    public void SetFishParameter(float span1, float delta, int ratio) //�ٸ� ��ũ��Ʈ���� ������ �� �ֵ��� public�����صα�
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

            float x = Random.Range(-4, 1); //���� ����
            everyFish.transform.position = new Vector2(x, 6);
        }
    }
}
