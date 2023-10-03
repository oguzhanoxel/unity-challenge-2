using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform projectileSpawnPoint;
    public float horizontalInput;
    public float verticalInput;
    public float speed = 20f;
    public float xRange = 16f;
    public float zTopRange = 12f;
    public float zBottomRange = 0f;


    public GameObject projectilePrefab;

    private void Update()
    {
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        
        if (transform.position.z > zTopRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zTopRange);
        }

        if (transform.position.z < zBottomRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBottomRange);
        }

        // Player Vertical Position Input
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);

        // Player Horizontal Position Input
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, projectileSpawnPoint.position, projectilePrefab.transform.rotation);
        }
    }
}
