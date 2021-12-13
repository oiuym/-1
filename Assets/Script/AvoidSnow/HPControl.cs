using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPControl : MonoBehaviour
{
    GameObject hpImage;
    GameObject ground;
    GameObject pointText;
    float delta = 0;

    void Start()
    {
        hpImage = GameObject.Find("MiniHP");
        ground = GameObject.Find("Mountain");
        this.pointText = GameObject.Find("Point");
    }

    public void HPDecrease()
    {
        hpImage.GetComponent<Image>().fillAmount -= 0.25f;
    }

    void Update()
    {
        delta += Time.deltaTime;
        if (delta >= 1.0f)
        {
            StaticMember.point += 10 * (int)delta;
            delta = 0;
        }

        //if (delta >= 1)
        //{
        //a = (int)delta;
        //a = a * 10;
        //StaticMember.point += delta;
        //a = 0;
        //delta = 0;
        //}
        this.pointText.GetComponent<Text>().text = StaticMember.point.ToString() + " point";

        if (hpImage.GetComponent<Image>().fillAmount == 0)
        {
            Destroy(ground);
        }
    }

}
