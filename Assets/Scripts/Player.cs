using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private float score;
    public float movementSpeed;
    public GameObject explosion;


    private bool movingLeft;
    private float rotationSpeed;

    public Text scoreText;

    private void Start()
    {
        score = 0;
        movingLeft = true;
    }

    private void Update()
    {
        score += Time.deltaTime;
        transform.Translate(Vector3.down * Time.deltaTime * movementSpeed);

        //player movement
        if(Input.GetMouseButtonDown(0))
        {
            rotationSpeed = 0.5f;
            movingLeft = !movingLeft;
        }

        if(Input.GetMouseButton(0))
        {
            rotationSpeed += 1.5f * Time.deltaTime;
        }

        if (movingLeft)
        {
            transform.Rotate(0, 0, rotationSpeed);
        }
        else
        {
            transform.Rotate(0, 0, -rotationSpeed);
        }


    }

    private void FixedUpdate()
    {
        scoreText.GetComponent<Text>().text = "Score: " + Mathf.RoundToInt(score);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Obstacle")
        {
            Die();
        }
    }

    void Die()
    {
        print("player dead");

        Vector3 explosionLocation;
        explosionLocation = this.gameObject.transform.position;
        explosionLocation.z = explosionLocation.z - 3;

        Instantiate(explosion, explosionLocation, this.gameObject.transform.rotation );

        Destroy(this.gameObject);
    }
}
