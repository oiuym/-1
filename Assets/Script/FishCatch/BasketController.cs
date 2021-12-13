using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketController : MonoBehaviour
{
    public AudioClip getBaksetSE; //����� �ҽ� ���Ա� ����
    public AudioClip throwSE; //����� �ҽ� ���Ա� ����
    AudioSource aud; //AudioSource�� �ٷ��.

    public float throwSpeed = 0.07f;
    float delta = 0;

    // Start is called before the first frame update
    void Start()
    {
        this.aud = GetComponent<AudioSource>(); //�� ��� Component��ġ�ϱ�
        this.aud.PlayOneShot(this.getBaksetSE);
    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta == 2.0f) this.aud.PlayOneShot(this.throwSE);
        if (this.delta > 2.0f) //Basket�� �����ϴ�.
        {
            transform.Translate(this.throwSpeed, this.throwSpeed, 0);
            transform.Rotate(0, 0, 0.5f);
        }

        if (transform.position.y > 6.5f) //Basket�� y��ǥ�� 6.5 �̻��̸�
        {
            Destroy(gameObject); //Basket ����
        }
    }
}
