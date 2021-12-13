using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public void OnClickStartButton()
    {
        SceneManager.LoadScene("MainGameScene");
    }

    public void OnClickTipButton()
    {
        SceneManager.LoadScene("TipScene");
    }

    public void OnClickBackButton()
    {
        SceneManager.LoadScene("TitleScene");
    }

    public void OnClickQuitButton()
    {
        Application.Quit();
    }
}
