using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketController : MonoBehaviour
{
    public AudioClip getBaksetSE; //오디오 소스 투입구 마련
    public AudioClip throwSE; //오디오 소스 투입구 마련
    AudioSource aud; //AudioSource를 다룬다.

    public float throwSpeed = 0.07f;
    float delta = 0;

    // Start is called before the first frame update
    void Start()
    {
        this.aud = GetComponent<AudioSource>(); //각 기능 Component매치하기
        this.aud.PlayOneShot(this.getBaksetSE);
    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta == 2.0f) this.aud.PlayOneShot(this.throwSE);
        if (this.delta > 2.0f) //Basket을 던집니다.
        {
            transform.Translate(this.throwSpeed, this.throwSpeed, 0);
            transform.Rotate(0, 0, 0.5f);
        }

        if (transform.position.y > 6.5f) //Basket의 y좌표가 6.5 이상이면
        {
            Destroy(gameObject); //Basket 삭제
        }
    }
}
