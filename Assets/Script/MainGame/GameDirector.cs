using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    GameObject distanceText;
    GameObject pointText;
    GameObject hpGauge;
    //public static float distance = 0f;
    //public static int point = 0;

    void Start()
    {
        this.distanceText = GameObject.Find("Distance");
        this.pointText = GameObject.Find("Point");
        this.hpGauge = GameObject.Find("Hpgauge");
    }

    public void DecreaseHp()
    {
        StaticMember.hp -= 1;
        //this.hpGauge.GetComponent<Image>().fillAmount -= 0.21f;
    }

    void Update()
    {
        StaticMember.second += Time.deltaTime;
        StaticMember.distance += Time.deltaTime * 10;

        this.hpGauge.GetComponent<Image>().fillAmount = StaticMember.hp / 5;

        this.distanceText.GetComponent<Text>().text = StaticMember.distance.ToString("F1") + " m";
        this.pointText.GetComponent<Text>().text = StaticMember.point.ToString() + " point";

        if (this.hpGauge.GetComponent<Image>().fillAmount <= 0)
        {
            SceneManager.LoadScene("DeadScene");
            //StaticMember.distance = 0;
            //StaticMember.point = 0;
            //StaticMember.span = 5.0f;
        }
    }
}
