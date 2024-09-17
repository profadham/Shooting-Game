using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerHealth : MonoBehaviour
{
    private int Health;
    public Slider healthSlider;
    private const int MAX_HEALTH = 100;
    public GameObject playerDestroyedPrefab;

    

    private void Start()
    {
        Health = MAX_HEALTH;
        
    }

    public void DeacreaseHealth(int amountOfHealth)
    {
        Health -= amountOfHealth;
        healthSlider.value = Health;

        if (Health < 0)
        {
            //Instantiate(playerDestroyedPrefab, transform.position, Quaternion.identity);
            
            Destroy(gameObject);
            SceneManager.LoadScene(2);
        }
    }
}
