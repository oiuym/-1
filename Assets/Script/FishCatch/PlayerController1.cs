using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController1 : MonoBehaviour
{
    Rigidbody2D rigid2D; //Rigidbody�� �ٷ��.
    Animator animator; //�ִϸ��̼��� �ٷ��.
    float jumpForce = 680.0f; //���� ���� ����

    public AudioClip getFishSE; //����� �ҽ� ���Ա� ����
    public AudioClip getStarfishSE; //����� �ҽ� ���Ա� ����
    public AudioClip getFish2SE; //����� �ҽ� ���Ա� ����
    AudioSource aud; //AudioSource�� �ٷ��.

    public GameObject balloonHappyPrefab; //��ǳ�� �ҽ� ���Ա� ����

    GameObject director; //�������� �Լ� ������ ��� ����

    // Start is called before the first frame update
    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>(); //�� ��� Component��ġ�ϱ�
        this.animator = GetComponent<Animator>(); //�� ��� Component��ġ�ϱ�
        this.aud = GetComponent<AudioSource>(); //�� ��� Component��ġ�ϱ�
        this.director = GameObject.Find("FishCatchDirector"); //��ο� ����(director) ��ġ�ϱ�
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject balloon;
        if (other.gameObject.tag == "fish1")
        {
            this.director.GetComponent<FishCatchDirector>().GetFish(); //�������� Fish����ٰ� ��ȣ
            this.aud.PlayOneShot(this.getFishSE); //ȿ����
        }
        else if (other.gameObject.tag == "starfish")
        {
            this.director.GetComponent<FishCatchDirector>().GetStarfish(); //�������� Starfish����ٰ� ��ȣ
            this.aud.PlayOneShot(this.getStarfishSE); //ȿ����
        }
        else if (other.gameObject.tag == "fish2")
        {
            this.director.GetComponent<FishCatchDirector>().GetGoldFish(); //�������� GoldFish����ٰ� ��ȣ
            this.aud.PlayOneShot(this.getFish2SE); //ȿ����
            balloon = Instantiate(balloonHappyPrefab) as GameObject; //��ǳ�� : ���
        }
        Destroy(other.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && this.rigid2D.velocity.y == 0) //Ŭ���ϰų�(�����) �����̽���(PC)
        {
            this.animator.SetTrigger("JumpTrigger"); //���� ��� ���� �� �ʿ��� Ʈ����
            this.rigid2D.AddForce(transform.up * this.jumpForce); //���� ���� ���� �°� �����մϴ�.
        }
        else if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && this.rigid2D.velocity.y < 0)
            this.rigid2D.AddForce(transform.up * this.jumpForce / 2); //���� ������ ���� ������ 2�� ����

        if (this.rigid2D.velocity.y == 0)
        {
            this.animator.speed = 1.0f / 1.0f; // �� ��ȯ �ӵ��� ���� ��� �޸��� ��� �ӵ� ���� ����
        }
        else
        {
            this.animator.speed = 1.0f;
        }

        if (transform.position.y < -5.0f) //�÷��̾��� y��ǥ�� -5 ���Ϸ� �������� ��
        {
            SceneManager.LoadScene("MainGameScene2"); //����ٰ� �� ��ȯ �ڵ带 �־��ּ���
        }
    }

    
}
