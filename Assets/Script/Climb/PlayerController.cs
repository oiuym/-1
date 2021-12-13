using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    Animator animator;
    float jumpForce = 500.0f;
    float walkForce = 30.0f;
    float maxWalkSpeed = 4.0f;
    int jumpCount = 0;
    float threshold = 0.2f;

    public AudioClip getFish2SE; //오디오 소스 투입구 마련
    AudioSource aud; //AudioSource를 다룬다.

    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
        this.aud = GetComponent<AudioSource>(); //각 기능 Component매치하기
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "flag")
        {
            this.aud.PlayOneShot(this.getFish2SE);
            StaticMember.point += 1000;
            SceneManager.LoadScene("MainGameScene2");
        }
    }

        void Update()
    {
        StaticMember.second += Time.deltaTime;

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

        if (transform.position.y < -40.0f)
        {
            SceneManager.LoadScene("MainGameScene2"); //여기다가 씬 전환 코드를 넣어주세요
        }

        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow) || Input.acceleration.x > this.threshold) key = 1;
        if (Input.GetKey(KeyCode.LeftArrow) || Input.acceleration.x < -this.threshold) key = -1;

        // 플레이어의 속도
        float speedx = Mathf.Abs(this.rigid2D.velocity.x);

        // 스피드 제한
        if (speedx < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
        }

        // 움직이는 방향에 따라 반전한다.
        if (key != 0)
        {
            transform.localScale = new Vector3(key * 5, 5, 1);
        }

    }        

}