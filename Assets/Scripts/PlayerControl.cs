using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerControl : MonoBehaviour
{

    private Rigidbody playerRB;

    private Animator animator;

    private AudioSource audio;

    


    [SerializeField] private AudioClip jumpClip;
    [SerializeField] private AudioClip deathClip;


    private bool isOnGround;

    private float jumpForce = 8f;

    [SerializeField] private float vol = 0.5f;

    public bool isGameOver;

    [SerializeField] private ParticleSystem deathP;
    [SerializeField] private ParticleSystem dirt;

    [SerializeField] private AudioSource cameraAudio;


    private int lives = 3;

    public TMP_Text contadorLives;



    private void Awake()
    {
        playerRB = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
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

        contadorLives.text = $"Lives{lives}";


        if(!isGameOver)
        {

            cameraAudio.volume = vol;

        }
        

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
            audio.PlayOneShot(deathClip, vol);
            dirt.Stop();

        }
        
        
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Ground" && !isGameOver) 
        {

            isOnGround = true;
            dirt.Play();

        
        }

        if (collision.gameObject.tag == "Obstacle")
        {

            lives--;
            if (lives < 0)
            {
                death();
            }
            
            

        }


        
        
    }

    private void death()
    {

        Debug.Log("Game Over");
        //Time.timeScale  = 0;
        isGameOver = true;
        animator.SetBool("Death_b",true);
        deathP.Play();
        audio.PlayOneShot(deathClip, vol);
        cameraAudio.volume = 0.01f;
        dirt.Stop();
        


    }

    





}
