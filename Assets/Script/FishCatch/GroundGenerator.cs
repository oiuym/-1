using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{
    public GameObject GroundPrefab;

    float span1 = 2.5f; //���� �ֱ�
    float delta = 1.8f; //���� �ֱ� ����ϱ� ���� ��Ÿ�� �ʱⰪ

    public void SetGroundParameter(float span1, float delta) //�ٸ� ��ũ��Ʈ���� ������ �� �ֵ��� public�����صα�
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
