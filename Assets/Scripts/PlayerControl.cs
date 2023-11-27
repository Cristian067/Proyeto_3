using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{

    private Rigidbody playerRB;

    private Animator animator;

    private bool isOnGround;

    private float jumpForce = 8f;


    public bool isGameOver;

    [SerializeField] private ParticleSystem deathP;
    [SerializeField] private ParticleSystem dirt;





    private void Awake()
    {
        playerRB = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        isOnGround = true;
        isGameOver = false;
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

        if (Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene("Prototype 3");
        }
        
    }


    private void jump()
    {
        if (isOnGround && !isGameOver)
        {
            playerRB.AddForce(new Vector3(0, 1, 0) * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            animator.SetTrigger("Jump_trig");
            dirt.Stop();

        }
        
        
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Ground") 
        {

            isOnGround = true;
            dirt.Play();

        
        }

        if (collision.gameObject.tag == "Obstacle")
        {
            
            death();

        }


        
        
    }

    private void death()
    {

        Debug.Log("Game Over");
        //Time.timeScale  = 0;
        isGameOver = true;
        animator.SetBool("Death_b",true);
        deathP.Play();
        


    }

    





}
