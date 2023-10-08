using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Quirell thePlayer;
    [HideInInspector] public bool doorOpen, waitingToOpen;
    
    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<Quirell>();
    }

    // Update is called once per frame
    void Update()
    {
        if(waitingToOpen)
        {
            if(Vector3.Distance(thePlayer.followingKey.transform.position, transform.position) <0.01f)
            {
                waitingToOpen = false;
                doorOpen = true;
                gameObject.SetActive(false);
                thePlayer.followingKey.gameObject.SetActive(false);


            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(thePlayer.followingKey != null)
            {
                thePlayer.followingKey.followTarget = transform;
                waitingToOpen = true;
            }
        }
    }
}
