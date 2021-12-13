using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PenguinController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    Animator animator;
    float jumpForce = 500.0f;
    int jumpCount = 0;
    float i = 0;

    public AudioClip getFishSE; //오디오 소스 투입구 마련
    public AudioClip getStarfishSE; //오디오 소스 투입구 마련
    public AudioClip getFish2SE; //오디오 소스 투입구 마련
    public AudioClip icelakeSE; //오디오 소스 투입구 마련
    AudioSource aud; //AudioSource를 다룬다.

    public GameObject balloonHappyPrefab; //말풍선 소스 투입구 마련
    GameObject director; //감독에게 함수 전달할 통로 마련

    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
        this.aud = GetComponent<AudioSource>(); //각 기능 Component매치하기
        this.director = GameObject.Find("FishCatchDirector"); //통로와 감독(director) 매치하기
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "fishcatch")
        {
            SceneManager.LoadScene("PenguinFishCatchScene");
            Destroy(other.gameObject);
        }
        
        if (other.gameObject.tag == "avoidsnow")
        {
            SceneManager.LoadScene("AvoidSnowScene");
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "climb")
        {
            SceneManager.LoadScene("ClimbPenguinScene");
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "mainfish")
        {
            StaticMember.point += 10;
            this.aud.PlayOneShot(this.getFishSE);
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Trap")
        {
            GameObject director = GameObject.Find("GameDirector");
            this.aud.PlayOneShot(this.getStarfishSE);
            director.GetComponent<GameDirector>().DecreaseHp();
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "fish1")
        {
            this.director.GetComponent<FishCatchDirector>().GetFish(); //감독에게 Fish얻었다고 신호
            this.aud.PlayOneShot(this.getFishSE); //효과음
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "starfish")
        {
            this.director.GetComponent<FishCatchDirector>().GetStarfish(); //감독에게 Starfish얻었다고 신호
            this.aud.PlayOneShot(this.getStarfishSE); //효과음
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "fish2")
        {
            GameObject balloon;
            this.director.GetComponent<FishCatchDirector>().GetGoldFish(); //감독에게 GoldFish얻었다고 신호
            this.aud.PlayOneShot(this.getFish2SE); //효과음
            balloon = Instantiate(balloonHappyPrefab) as GameObject; //말풍선 : 기쁨
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "icelake")
        {
            GameObject director = GameObject.Find("GameDirector");
            this.aud.PlayOneShot(this.icelakeSE);
            this.i = 0; //연속기 맞도록
            this.jumpForce = 50.0f;//점프력 몇초간 하락
            director.GetComponent<GameDirector>().DecreaseHp();
        }
    }

    void Update()
    {
        if (this.jumpForce < 60.0f)
        {
            this.i += Time.deltaTime;
            if (this.i > 5) // 5초간 점프력 하락
            {
                this.jumpForce = 500.0f;
                this.i = 0;
            }
        }

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && jumpCount <= 1)
        {
            this.animator.SetTrigger("JumpTrigger");
            this.rigid2D.AddForce(transform.up * this.jumpForce);
            jumpCount += 1;
        }

        if (this.rigid2D.velocity.y == 0 && jumpCount == 2)
        {
            jumpCount += 1;
        }

        if (this.rigid2D.velocity.y == 0 && jumpCount == 3)
        {
            jumpCount = 0;
        }

        if (transform.position.y < -15.0f) //플레이어의 y좌표가 -5 이하로 떨어졌을 때
        {
            SceneManager.LoadScene("MainGameScene2"); //여기다가 씬 전환 코드를 넣어주세요
        }
    }
}
