using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPControl : MonoBehaviour
{
    GameObject hpImage;

    void Start()
    {
        hpImage = GameObject.Find("MiniHP");
    }

    public void HPDecrease()
    {
        hpImage.GetComponent<Image>().fillAmount += 0.25f;
    }
}
