using System;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using UnityEngine;


public class SpawnManager : MonoBehaviour
{

    [SerializeField]private GameObject[] obstacle;


    [SerializeField] private float startTime;
    [SerializeField] private float delayTime;
    [SerializeField] private float delayTimeA;
    [SerializeField] private float delayTimeB;


    private Vector3 spawnPos;


    private void Awake()
    {
        spawnPos = new Vector3(20f, 0, 0);
    }


    // Start is called before the first frame update
    void Start()
    {

        InvokeRepeating("obstacles", startTime, delayTime);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    
    }


    private void obstacles()
    {
        Instantiate(obstacle[Random.Range(0,obstacle.Length)], spawnPos, Quaternion.identity);
    }



}
