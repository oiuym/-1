using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    Rigidbody2D rigid2D;
    public AudioClip getStarfishSE; //오디오 소스 투입구 마련
    AudioSource aud;
    GameObject hpControl;


    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.aud = GetComponent<AudioSource>(); //각 기능 Component매치하기
        hpControl = GameObject.Find("HPControl");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "snowball")
        {
            this.aud.PlayOneShot(this.getStarfishSE);
            hpControl.GetComponent<HPControl>().HPDecrease();
            Destroy(other.gameObject);
        }
    }

    void Update()
    {
        StaticMember.second += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.LeftArrow) && transform.position.x > -8)
        {
            transform.Translate(-1, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && transform.position.x < 8)
        {
            transform.Translate(1, 0, 0);
        }

        if (transform.position.y < -20)
        {
            SceneManager.LoadScene("MainGameScene2");
        }
    }
}
