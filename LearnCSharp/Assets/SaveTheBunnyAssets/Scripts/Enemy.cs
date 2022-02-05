using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float rotationSpeed;
    public GameObject dust;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        transform.Rotate(0,0, rotationSpeed);
    }

    //Creating the dust effect after death
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
        }
        else if(collision.gameObject.tag == "Ground")
        {
            gameObject.SetActive(false);
            GameObject dustEffect = Instantiate(dust, transform.position, Quaternion.identity);

            Destroy(dustEffect, 2f);
            Destroy(gameObject, 3f);
        }
    }
}
