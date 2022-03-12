using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LD_Player : MonoBehaviour
{
    //Configuration Parameters
    [Header("Player")] 
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float padding = 0.5f; //Adding padding for the boundary of where the player can move.
    [SerializeField] int health = 200;

    [Header("Projectile")]
    [SerializeField] float projectileSpeed = 20f;
    [SerializeField] float projectileFiringPeriod = 0.2f;    
    [SerializeField] GameObject laserPrefab;

    Coroutine firingCoroutine; //Stores a reference to the Firing Coroutine, so when the button is let go, it will be stopped.

    float xMin;
    float xMax;
    float yMin;
    float yMax;


    // Start is called before the first frame update
    void Start()
    {
        SetUpMoveBoundaries();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Fire();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) { return; }
        ProcessHit(ref damageDealer);
    }

    //Gets the damage value and destroys enemy if health is less then 0.
    private void ProcessHit(ref DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    //Fires the laser, based on the player's position
    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            firingCoroutine = StartCoroutine(FireContinuously());
        }
        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(firingCoroutine);
        }
    }

    //A Corountine for firing when the button is held down.
    IEnumerator FireContinuously()
    {
        while (true)
        {
            GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity) as GameObject;
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);

            yield return new WaitForSeconds(projectileFiringPeriod);
        }
    }

    //Moves the player, based on directional inputs, and clamped based on Camera ViewportToWorldPoint
    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        var newYPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);
        transform.position = new Vector2(newXPos, newYPos);        
    }

    //Sets up the boundaries the player can move in, based on the Viewport of the camera.
    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        float cameraZPosition = gameCamera.transform.position.z;
        if (cameraZPosition < 0)
            cameraZPosition = -cameraZPosition;

        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, cameraZPosition)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, cameraZPosition)).x - padding;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, cameraZPosition)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, cameraZPosition)).y - padding;
    }
}
