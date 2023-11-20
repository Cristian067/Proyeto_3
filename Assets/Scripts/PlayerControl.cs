using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    private Rigidbody playerRB;

    private bool isOnGround;

    private float jumpForce = 8;





    private void Awake()
    {
        playerRB = GetComponent<Rigidbody>();
        isOnGround = true;
    }


    // Start is called before the first frame update
    void Start()
    {
        //playerRB.AddForce(new Vector3(0,1,0) * 10, ForceMode.Impulse);
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("space") && isOnGround)
        {
            jump();
        }
        
    }


    private void jump()
    {
        if (isOnGround)
        {
            playerRB.AddForce(new Vector3(0, 1, 0) * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
        
        
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Ground") 
        {

            isOnGround = true;
        
        }
        
    }





}
