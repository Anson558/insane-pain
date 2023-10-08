using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    
    private GameObject target;
    [SerializeField] private Rigidbody2D rb;
    private DeployMissiles deployScript;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float rotateSpeed = 300f;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player");
        deployScript = FindObjectOfType<DeployMissiles>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (deployScript.goBrr == true)
        {
            Vector2 direction = (Vector2)target.transform.position - rb.position;
            direction.Normalize();
            float rotateAmount = Vector3.Cross(direction, -transform.up).z;
            rb.angularVelocity = -rotateAmount * rotateSpeed;
            rb.velocity = -transform.up * speed;
        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
        }
    }

    

    

    
}   

