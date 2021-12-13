using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishCatchDirector : MonoBehaviour
{
    GameObject drop1generator; //스크립트에서 fish생성 멈추기 위해
    GameObject drop2generator; //스크립트에서 starfish생성 멈추기 위해
    GameObject drop3generator; //스크립트에서 ground생성 멈추기 위해

    GameObject pointText;
    float time = 30.0f;
    //int point = 0;

    public void GetFish()
    {
        StaticMember.point += 10;
    }

    public void GetStarfish()
    {
        StaticMember.point -= 20;
    }

    public void GetGoldFish()
    {
        StaticMember.point += 50;
    }

    // Start is called before the first frame update
    void Start()
    {
        this.drop1generator = GameObject.Find("FishGenerator");
        this.drop2generator = GameObject.Find("StarfishGenerator");
        this.drop3generator = GameObject.Find("GroundGenerator");
        this.pointText = GameObject.Find("Point");
    }

    // Update is called once per frame
    void Update()
    {
        this.time -= Time.deltaTime;
        if (this.time < 1.0f)
        {
            this.drop1generator.GetComponent<FishGenerator>().SetFishParameter(10.0f, 0, 3);
            this.drop2generator.GetComponent<StarfishGenerator>().SetStarfishParameter(10.0f, 0);
        }
        if (this.time < 0)
        {
            this.time = 0;
            this.drop3generator.GetComponent<GroundGenerator>().SetGroundParameter(10.0f, 0);
        }

        this.pointText.GetComponent<Text>().text = StaticMember.point.ToString() + " point";
    }
}
