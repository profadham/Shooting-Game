using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    public Transform[] spawnPoints;

    private playerMovement playerMovement;

    private void Awake()
    {
        playerMovement = FindObjectOfType<playerMovement>();
    }

    private void Start()
    {
        StartCoroutine(spawnEnemiesCoroutine());   
    }

    private IEnumerator spawnEnemiesCoroutine()
    {
        while (playerMovement != null)
        {
            GameObject enemy = Instantiate(enemyPrefab[Random.Range(0, enemyPrefab.Length)], spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);

            yield return (new WaitForSeconds(2));
        }
    }
}
