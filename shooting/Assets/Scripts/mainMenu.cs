using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class mainMenu : MonoBehaviour
{
    private int moneyAmount;
    public TMP_Text moneyText;
    

    private void Start()
    {
        moneyAmount = PlayerPrefs.GetInt("Money", 0);
        moneyText.text = moneyAmount.ToString();
    }

    public void play()
    {
        SceneManager.LoadScene(1);
    }
}

