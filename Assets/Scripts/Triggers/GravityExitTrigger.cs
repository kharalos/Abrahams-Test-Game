using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityExitTrigger : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<AudioSource>().Play();
        }
    }
    private void Update()
    {
        if (transform.position.y < -40f) Destroy(gameObject);
    }
}
