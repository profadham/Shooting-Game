using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject coin;

    private playerMovement playerMovement;

    private void Awake()
    {
        playerMovement = FindObjectOfType<playerMovement>();
    }

    private void Start()
    {
        StartCoroutine(spawnCoinsCoroutine());
        
    }

    private IEnumerator spawnCoinsCoroutine()
    {
        while (playerMovement != null)
        {
            GameObject Coin = Instantiate(coin, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
            Coin.transform.Rotate(0, 0, 90);
            yield return new WaitForSeconds(2);
        }
        
    }
}
