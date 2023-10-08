using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private bool isFollowing;
    [SerializeField] private float followSpeed;
    [HideInInspector]public Transform followTarget;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isFollowing == true)
        {
            transform.position = Vector3.Lerp(transform.position, followTarget.position, followSpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if(!isFollowing)
            {
                Quirell thePlayer = FindObjectOfType<Quirell>();

                followTarget = thePlayer.keyFollowPoint;

                isFollowing = true;
                thePlayer.followingKey = this;
            }
        }
    }
}
