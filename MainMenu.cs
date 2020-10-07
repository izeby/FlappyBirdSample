using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public Text bestText;
    public Text puanText;
    void Start()
    {
        int enYuksekPuan = PlayerPrefs.GetInt("enyuksekpuankayit");
        int Puan = PlayerPrefs.GetInt("puankayit");
        bestText.text = "Best :" + enYuksekPuan;
        puanText.text = "Score :" + Puan;

    }

 
    void Update()
    {
        
    }

    public void oyunaGit()
    {
        SceneManager.LoadScene("first");
    }

    public void oyundanCik()
    {
        Application.Quit();

    }
}
