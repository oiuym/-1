using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarfishGenerator : MonoBehaviour
{
    public GameObject starfishPrefab;

    float span1 = 1.5f; //���� �ֱ�
    float delta = 0; //���� �ֱ� ����ϱ� ���� ��Ÿ�� �ʱⰪ
    float startDelay = 2.5f; //�ٱ��� ������ �ð� ��ٸ���

    public void SetStarfishParameter(float span1, float delta) //�ٸ� ��ũ��Ʈ���� ������ �� �ֵ��� public�����صα�
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
            float x = Random.Range(0, 2); //���� ����
            everyFish.transform.position = new Vector2(x, 6);
        }
    }
}
