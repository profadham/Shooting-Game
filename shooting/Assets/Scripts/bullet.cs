using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

    public string targetTag;
    public TargetToDestroy target;

    public enum TargetToDestroy { Player, Enemy }
    public GameObject bulletDestroyedPrefab;
    public GameObject enemyDestroyedPrefab;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == targetTag)
        {
            if (target == TargetToDestroy.Enemy)
            {
                Destroy(collision.gameObject);
                FindObjectOfType<playerScore>().IncreaseScore();
                Instantiate(enemyDestroyedPrefab, collision.transform.position, Quaternion.identity);
            }
            else if (target == TargetToDestroy.Player)
            {
                collision.gameObject.GetComponent<playerHealth>().DeacreaseHealth(10);
                
            }
            
            
        }

        Instantiate(bulletDestroyedPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
        //Debug.Log(true);
        

    }
}
