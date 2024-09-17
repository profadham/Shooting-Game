using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class afterGameScript : MonoBehaviour
{
    public TMP_Text kills;
    public TMP_Text best;
    public TMP_Text moneyAmount;

    
    

    private void Start()
    {
        kills.text = PlayerPrefs.GetInt("kills", 0).ToString();
        best.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        moneyAmount.text = PlayerPrefs.GetInt("thisMoney", 0).ToString();
        PlayerPrefs.SetInt("kills", 0);
        PlayerPrefs.SetInt("thisMoney", 0);
    }

    public void goToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
