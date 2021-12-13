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

    public AudioClip getFishSE; //����� �ҽ� ���Ա� ����
    public AudioClip getStarfishSE; //����� �ҽ� ���Ա� ����
    public AudioClip getFish2SE; //����� �ҽ� ���Ա� ����
    public AudioClip icelakeSE; //����� �ҽ� ���Ա� ����
    AudioSource aud; //AudioSource�� �ٷ��.

    public GameObject balloonHappyPrefab; //��ǳ�� �ҽ� ���Ա� ����
    GameObject director; //�������� �Լ� ������ ��� ����

    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
        this.aud = GetComponent<AudioSource>(); //�� ��� Component��ġ�ϱ�
        this.director = GameObject.Find("FishCatchDirector"); //��ο� ����(director) ��ġ�ϱ�
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
            this.director.GetComponent<FishCatchDirector>().GetFish(); //�������� Fish����ٰ� ��ȣ
            this.aud.PlayOneShot(this.getFishSE); //ȿ����
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "starfish")
        {
            this.director.GetComponent<FishCatchDirector>().GetStarfish(); //�������� Starfish����ٰ� ��ȣ
            this.aud.PlayOneShot(this.getStarfishSE); //ȿ����
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "fish2")
        {
            GameObject balloon;
            this.director.GetComponent<FishCatchDirector>().GetGoldFish(); //�������� GoldFish����ٰ� ��ȣ
            this.aud.PlayOneShot(this.getFish2SE); //ȿ����
            balloon = Instantiate(balloonHappyPrefab) as GameObject; //��ǳ�� : ���
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "icelake")
        {
            GameObject director = GameObject.Find("GameDirector");
            this.aud.PlayOneShot(this.icelakeSE);
            this.i = 0; //���ӱ� �µ���
            this.jumpForce = 50.0f;//������ ���ʰ� �϶�
            director.GetComponent<GameDirector>().DecreaseHp();
        }
    }

    void Update()
    {
        if (this.jumpForce < 60.0f)
        {
            this.i += Time.deltaTime;
            if (this.i > 5) // 5�ʰ� ������ �϶�
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

        if (transform.position.y < -15.0f) //�÷��̾��� y��ǥ�� -5 ���Ϸ� �������� ��
        {
            SceneManager.LoadScene("MainGameScene2"); //����ٰ� �� ��ȯ �ڵ带 �־��ּ���
        }
    }
}
