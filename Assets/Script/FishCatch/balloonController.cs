using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balloonController : MonoBehaviour
{
    GameObject player; //player을 정의합니다.
    float delta = 0;

    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("Penguin0"); //정의한 player는 Penguin0의 오브젝트를 참조합니다.
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 playerPos = this.player.transform.position; //playerPos는 player의 좌표로 정의합니다.
        transform.position = new Vector2(playerPos.x - 1.5f, playerPos.y + 0.5f);

        this.delta += Time.deltaTime;
        if (this.delta > 1.0f) Destroy(gameObject);
    }
}
