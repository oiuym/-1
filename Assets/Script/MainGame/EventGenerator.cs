using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventGenerator : MonoBehaviour
{
    public GameObject mainfishPrefab;
    public GameObject trap0Prefab;
    public GameObject trap1Prefab;
    public GameObject trap2Prefab;
    public GameObject fishcatchopenPrefab;
    public GameObject fishcatch2Prefab;
    public GameObject snowmanPrefab;
    public GameObject climb0Prefab;
    public GameObject climb1Prefab;
    public GameObject icelakePrefab;

    float delta = 0;
    float delta1 = 0;
    float range = 0;
    int x = 10;

    void Update()
    {
        this.delta += Time.deltaTime;
        this.delta1 += Time.deltaTime;

        if (this.delta1 > 0.5)
        {
            GameObject item;
            item = Instantiate(mainfishPrefab) as GameObject;
            float height = Random.Range(-3.5f, 4.5f);
            item.transform.position = new Vector2(x, height);
            this.delta1 = 0;
        }

        this.range += Time.deltaTime * 10;

        if (this.range > 100 && StaticMember.span >= 1)
        {
            StaticMember.span -= 0.1f;
            this.range = 0;
        }

        if (this.delta > StaticMember.span)
        {
            this.delta = 0;
            GameObject item;
            GameObject item2;
            int dice = Random.Range(1, 101);
            if (dice <= 30)
            {
                item = Instantiate(trap0Prefab) as GameObject;
                item2 = Instantiate(trap1Prefab) as GameObject;
                //int x = 10;
                float y1 = -3.5f;
                float y2 = -2.5f;
                item.transform.position = new Vector2(x, y1);
                item2.transform.position = new Vector2(x, y2);
            }
            else if (dice > 30 && dice <= 60)
            {
                item = Instantiate(trap2Prefab) as GameObject;
                //int x = 10;
                int y = -2;
                item.transform.position = new Vector2(x, y);
            }
            else if (dice > 60 && dice <= 90)
            {
                item = Instantiate(icelakePrefab) as GameObject;
                //int x = 10;
                float y = -4.1f;
                item.transform.position = new Vector2(x + 2, y);
            }
            else if (dice > 90 && dice <= 94)
            {
                item = Instantiate(fishcatchopenPrefab) as GameObject;
                item2 = Instantiate(fishcatch2Prefab) as GameObject;
                //int x = 10;
                float y1 = -0.3f;
                float y2 = -0.5f;
                item.transform.position = new Vector2(x + 4, y1);
                item2.transform.position = new Vector2(x + 5, y2);
            }
            else if (dice > 94 && dice <= 97)
            {
                item = Instantiate(snowmanPrefab) as GameObject;
                //int x = 10;
                float y = -2.7f;
                item.transform.position = new Vector2(x, y);
            }
            else
            {
                item = Instantiate(climb0Prefab) as GameObject;
                item2 = Instantiate(climb1Prefab) as GameObject;
                //int x = 10;
                float y1 = -2.44f;
                float y2 = -1.92f;
                item.transform.position = new Vector2(x + 3, y1);
                item2.transform.position = new Vector2(x + 2.91f, y2);
            }
        }
    }
}
