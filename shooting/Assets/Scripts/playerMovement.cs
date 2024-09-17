using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Android;


public class playerMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    //public GameObject coin;
    private Animator playerAnimator;
    private float verticalValue;
    public bool isShooting;
    public LayerMask intaract;
    private int money;
    public TMP_Text moneyText;
    public FixedJoystick joystick;
    public Rigidbody rb;
    public Vector3 oldPos;
    public Vector3 newPos;
    public int thisMoney;


    // Start is called before the first frame update
    void Awake()
    {
        playerAnimator = GetComponentInChildren<Animator>();
        money = PlayerPrefs.GetInt("Money", 0);
        moneyText.text = money.ToString();
        rb = GetComponentInChildren<Rigidbody>();
        oldPos = transform.position;
        newPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        verticalValue = Input.GetAxisRaw("Vertical");

        //if (!isShooting)
        //{
          //  Move();
        //}
        
        //Turn();
    }

    private void FixedUpdate()
    {
        //newPos = transform.position;
        if (!isShooting)
        {
            if (joystick.Horizontal != 0 || joystick.Vertical != 0)
            {
                //Debug.Log(joystick.Horizontal);
                playerAnimator.SetBool("fire", false);
                playerAnimator.SetBool("running", true);
                playerAnimator.SetFloat("Direction", 1);
                //Debug.Log(playerAnimator.GetBool("running"));
                //Debug.Log(playerAnimator.GetFloat("Direction"));
                //playerAnimator.SetFloat("Direction", joystick.Horizontal);
                transform.position += new Vector3(joystick.Horizontal, 0, joystick.Vertical) * moveSpeed * Time.deltaTime;
                //newPos.x *= -1;
                //newPos.z *= -1;
                //newPos.y = 0;
                
                //transform.rotation = Quaternion.Inverse(transform.LookAt(newPos));
                //transform.Rotate(Quaternion.LookRotation(newPos - oldPos), Vector3.forward);
            }
            if (joystick.Horizontal == 0 && joystick.Vertical == 0)
            {
                playerAnimator.SetBool("running", false);
                playerAnimator.SetFloat("Direction", 0);
            }
            //oldPos = newPos;

        }

        newPos = transform.position;
        newPos.x += joystick.Horizontal * moveSpeed;
        newPos.z += joystick.Vertical * moveSpeed;
        transform.LookAt(newPos);
    }

    private void Move()
    {
        /*if (Input.GetMouseButton(0))
        {
            playerAnimator.SetBool("fire", true);
        }
        if (Input.GetMouseButtonUp(0))
        {
            playerAnimator.SetBool("fire", false);
        }*/
        if (verticalValue != 0)
        {
            playerAnimator.SetBool("running", true);
            playerAnimator.SetFloat("Direction", verticalValue);
            Debug.Log(true);
            transform.position += transform.forward * moveSpeed * verticalValue * Time.deltaTime;
            //transform.position += transform.forward * moveSpeed * joystick.Horizontal * Time.deltaTime;
            //transform.position += new Vector3(joystick.Horizontal, 0, joystick.Vertical) * moveSpeed * Time.deltaTime;
            //transform.position = new Vector3(transform.position.x + joystick.Horizontal * moveSpeed * Time.deltaTime, transform.position.y,transform.position.z + joystick.Vertical * moveSpeed * Time.deltaTime);
        }

        
        else
        {
            playerAnimator.SetBool("running", false);
        }
    }

    private void Turn()
    {
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit groundHit;

        if (Physics.Raycast(cameraRay, out groundHit, Mathf.Infinity, intaract))
        {
            Vector3 PlayerToMouse = groundHit.point - transform.position;
            PlayerToMouse.y = 0;

            if (Vector3.Distance(transform.position, groundHit.point) < 3)
            {
                return;
            }
            Quaternion newRotation = Quaternion.LookRotation(PlayerToMouse);
            transform.rotation = newRotation;
            //transform.LookAt(PlayerToMouse);
        }

    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Coin")
        {
            money++;
            thisMoney++;
            PlayerPrefs.SetInt("thisMoney", thisMoney);
            PlayerPrefs.SetInt("Money", money);
            moneyText.text = money.ToString();
            Destroy(collider.gameObject);
            
        }
    }

}
