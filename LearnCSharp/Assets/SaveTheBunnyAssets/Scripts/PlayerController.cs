using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;

    float xInput;
    Vector2 newPosition;

    public float moveSpeed;
    public float xPositionLimit;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        xInput = Input.GetAxis("Horizontal");

        newPosition = transform.position;
        newPosition.x += xInput * moveSpeed;

        //Useful to set boundaries
        newPosition.x = Mathf.Clamp(newPosition.x, -xPositionLimit, xPositionLimit);

        rb2d.MovePosition(newPosition);
    }
}
