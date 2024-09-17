using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class playerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform fireSpawnPoint;
    public float fireRate = 0.05f;
    private Animator playerAnimator;
    private float nextBullet;
    playerMovement playermovement;
    public AudioSource shootSound;
    public Button shootButton;
    private bool shooting;

    private void Awake()
    {
        playerAnimator = GetComponentInChildren<Animator>();
        playermovement = GetComponent<playerMovement>();
    }

    private void Update()
    {
        /*if (Input.GetMouseButton(0))
        {
            playerAnimator.SetBool("fire", true);
            playermovement.isShooting = true;

            if (Time.time > nextBullet)
            {
                
                nextBullet = Time.time + fireRate;

                GameObject bullets = Instantiate(bulletPrefab, fireSpawnPoint.position, Quaternion.identity);
                shootSound.Play();
                bullets.GetComponent<Rigidbody>().velocity = transform.forward * 50;

                bullets.GetComponent<bullet>().targetTag = "Enemy";
                bullets.GetComponent<bullet>().target = bullet.TargetToDestroy.Enemy;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            playermovement.isShooting = false;
            playerAnimator.SetBool("fire", false);
        }*/

        //if (shootButton != )
        //shootButton.onClick.AddListener(shoot);
        if (shooting)
        {
            Debug.Log("entered");
            playerAnimator.SetBool("fire", true);
            playermovement.isShooting = true;

            if (Time.time > nextBullet)
            {

                nextBullet = Time.time + fireRate;
                //Debug.Log(Time.time);
                //Debug.Log(nextBullet);
                GameObject bullets = Instantiate(bulletPrefab, fireSpawnPoint.position, Quaternion.identity);
                shootSound.Play();
                bullets.GetComponent<Rigidbody>().velocity = transform.forward * 50;

                bullets.GetComponent<bullet>().targetTag = "Enemy";
                bullets.GetComponent<bullet>().target = bullet.TargetToDestroy.Enemy;
            }
        }
    }

    public void startShoot()
    {
        shooting = true;
    }

    public void stopShoot()
    {
        Debug.Log(true);
        playerAnimator.SetBool("fire", false);
        playermovement.isShooting = false;
        shooting = false;
    }
    
}
