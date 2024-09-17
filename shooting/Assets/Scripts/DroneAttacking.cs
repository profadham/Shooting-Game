using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneAttacking : EnemyAttacking
{

    public GameObject bulletPrefab;
    public Transform FireSpawnPoint;
    public float fireRate = 50f;
    //public AudioSource shooting;

    public float NextBullet;
    //private bool attackingActive = false;
    //public float shootTiner = 0f;


    public override void Attack()
    {
        if (Time.time > NextBullet)
        {
            
            NextBullet = Time.time + 0.25f;

            GameObject Bullet = Instantiate(bulletPrefab, FireSpawnPoint.position, Quaternion.identity);
            //shooting.Play();
            Bullet.GetComponent<Rigidbody>().velocity = transform.forward * -50;
            //Debug.Log(gameObject.transform.position.z - Bullet.transform.position.z);

            Bullet.GetComponent<bullet>().targetTag = "Player";
            Bullet.GetComponent<bullet>().target = bullet.TargetToDestroy.Player;
            
        }
        

    }

   


}
