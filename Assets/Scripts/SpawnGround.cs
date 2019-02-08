using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGround : MonoBehaviour
{
    public GameObject track;
    public bool spawned;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && !spawned)
        {
            Vector3 pos = new Vector3(transform.parent.position.x, (transform.parent.position.y - 20f), transform.parent.position.z);
            Instantiate(track.transform, pos, transform.parent.rotation);
            spawned = true;
        }
    }

}
