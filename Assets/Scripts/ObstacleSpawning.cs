using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawning : MonoBehaviour
{
    public GameObject player;

    public GameObject obstacle;
    public float amountOfObstacles;

    public float minX, maxX;

    public void Start()
    {
        player = GameObject.FindWithTag("Player");

        for (int i = 0; i < amountOfObstacles; i++)
        {
            float xAXIS, yAXIS;
            xAXIS = Random.Range(minX, maxX);
            yAXIS = Random.Range(player.transform.localPosition.y - 20, player.transform.localPosition.y - 50);

            Vector3 pos = new Vector3(xAXIS,yAXIS, 0);
            Instantiate(obstacle.transform, pos, Quaternion.identity);
        }
    }



}
