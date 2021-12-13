using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeadSceneDirector : MonoBehaviour
{
    GameObject secondText;
    GameObject pointText;

    void Start()
    {
        this.secondText = GameObject.Find("Time");
        this.pointText = GameObject.Find("Point");
        this.secondText.GetComponent<Text>().text = StaticMember.second.ToString("F1") + " √ ";
        this.pointText.GetComponent<Text>().text = StaticMember.point.ToString();
    }

}
