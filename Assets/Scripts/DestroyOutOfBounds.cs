using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 30f;
    private float lowerBound = -10f;
    private float horizontalBound = 30f;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        } else if (transform.position.z < lowerBound)
        {
            gameManager.AddLives(-1);
            Destroy(gameObject);
        } else if (transform.position.x > horizontalBound)
        {
            gameManager.AddLives(-1);
            Destroy(gameObject);
        } else if (transform.position.x < -horizontalBound)
        {
            gameManager.AddLives(-1);
            Destroy(gameObject);
        }
    }
}
