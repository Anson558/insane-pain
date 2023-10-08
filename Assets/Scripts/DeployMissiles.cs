using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployMissiles : MonoBehaviour
{
    [SerializeField] private AudioSource shootSound;
    public bool goBrr;
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "Player")
        {
            if (goBrr == false)
            {
                goBrr = true;
                shootSound.Play();
            }
        }

    }

    

    void Start()
    {
        //colliding = false;
        goBrr = false;
    }


   
}
