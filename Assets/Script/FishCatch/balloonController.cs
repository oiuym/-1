using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balloonController : MonoBehaviour
{
    GameObject player; //player�� �����մϴ�.
    float delta = 0;

    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("Penguin0"); //������ player�� Penguin0�� ������Ʈ�� �����մϴ�.
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 playerPos = this.player.transform.position; //playerPos�� player�� ��ǥ�� �����մϴ�.
        transform.position = new Vector2(playerPos.x - 1.5f, playerPos.y + 0.5f);

        this.delta += Time.deltaTime;
        if (this.delta > 1.0f) Destroy(gameObject);
    }
}
