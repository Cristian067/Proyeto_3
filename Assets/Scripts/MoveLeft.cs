using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{

    [SerializeField] private float speed = 30f;

    private PlayerControl playerControlS;




    // Start is called before the first frame update
    void Start()
    {

        playerControlS = FindAnyObjectByType<PlayerControl>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!playerControlS.isGameOver)
        {
            transform.Translate(new Vector3(-1, 0, 0) * speed * Time.deltaTime, Space.World);
        }
        
    }
}
