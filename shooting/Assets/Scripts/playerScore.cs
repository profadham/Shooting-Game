using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class playerScore : MonoBehaviour
{
    public TMP_Text currentScTxt;
    public TMP_Text highScTxt;

    public int currentScore;
    public int highScore;

    public playerScore instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }


    private void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScTxt.text = highScore.ToString();
    }
    public void IncreaseScore()
    {
        currentScore++;
        currentScTxt.text = currentScore.ToString();
        PlayerPrefs.SetInt("kills", currentScore);

        if (currentScore >= highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("HighScore", highScore);
        }
        
    }
}
