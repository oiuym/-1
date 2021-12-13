using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountainGenerator : MonoBehaviour
{
    public GameObject MountainPrefab;

    float span1 = 6.0f; //���� �ֱ�
    float delta = 3.0f; //���� �ֱ� ����ϱ� ���� ��Ÿ�� �ʱⰪ

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
