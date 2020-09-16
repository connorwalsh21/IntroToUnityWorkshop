using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Text text;
    void Start()
    {
        float BestTime = PlayerPrefs.GetFloat("fastestTime", 10000);
        text.text = "Fastest Time: " + BestTime + " seconds!";
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }
}
