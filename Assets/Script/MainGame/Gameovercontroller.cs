using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gameovercontroller : MonoBehaviour
{
    GameObject secondText;
    GameObject pointText;

    void start()
    {
        this.secondText = GameObject.Find("Time");
        this.pointText = GameObject.Find("Point");
    }

    void update()
    {
        this.secondText.GetComponent<Text>().text = StaticMember.second.ToString("F1") + " √ ";
        this.pointText.GetComponent<Text>().text = StaticMember.point.ToString() + StaticMember.distance.ToString();
    }
}
