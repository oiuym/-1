using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController1 : MonoBehaviour
{
    Rigidbody2D rigid2D; //Rigidbody를 다룬다.
    Animator animator; //애니메이션을 다룬다.
    float jumpForce = 680.0f; //점프 세기 설정

    public AudioClip getFishSE; //오디오 소스 투입구 마련
    public AudioClip getStarfishSE; //오디오 소스 투입구 마련
    public AudioClip getFish2SE; //오디오 소스 투입구 마련
    AudioSource aud; //AudioSource를 다룬다.

    public GameObject balloonHappyPrefab; //말풍선 소스 투입구 마련

    GameObject director; //감독에게 함수 전달할 통로 마련

    // Start is called before the first frame update
    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>(); //각 기능 Component매치하기
        this.animator = GetComponent<Animator>(); //각 기능 Component매치하기
        this.aud = GetComponent<AudioSource>(); //각 기능 Component매치하기
        this.director = GameObject.Find("FishCatchDirector"); //통로와 감독(director) 매치하기
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject balloon;
        if (other.gameObject.tag == "fish1")
        {
            this.director.GetComponent<FishCatchDirector>().GetFish(); //감독에게 Fish얻었다고 신호
            this.aud.PlayOneShot(this.getFishSE); //효과음
        }
        else if (other.gameObject.tag == "starfish")
        {
            this.director.GetComponent<FishCatchDirector>().GetStarfish(); //감독에게 Starfish얻었다고 신호
            this.aud.PlayOneShot(this.getStarfishSE); //효과음
        }
        else if (other.gameObject.tag == "fish2")
        {
            this.director.GetComponent<FishCatchDirector>().GetGoldFish(); //감독에게 GoldFish얻었다고 신호
            this.aud.PlayOneShot(this.getFish2SE); //효과음
            balloon = Instantiate(balloonHappyPrefab) as GameObject; //말풍선 : 기쁨
        }
        Destroy(other.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && this.rigid2D.velocity.y == 0) //클릭하거나(모바일) 스페이스바(PC)
        {
            this.animator.SetTrigger("JumpTrigger"); //점프 모션 넣을 때 필요할 트리거
            this.rigid2D.AddForce(transform.up * this.jumpForce); //점프 세기 값에 맞게 점프합니다.
        }
        else if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && this.rigid2D.velocity.y < 0)
            this.rigid2D.AddForce(transform.up * this.jumpForce / 2); //점프 세기의 절반 값으로 2단 점프

        if (this.rigid2D.velocity.y == 0)
        {
            this.animator.speed = 1.0f / 1.0f; // 맵 전환 속도에 따른 펭귄 달리기 모션 속도 조절 가능
        }
        else
        {
            this.animator.speed = 1.0f;
        }

        if (transform.position.y < -5.0f) //플레이어의 y좌표가 -5 이하로 떨어졌을 때
        {
            SceneManager.LoadScene("MainGameScene2"); //여기다가 씬 전환 코드를 넣어주세요
        }
    }

    
}
