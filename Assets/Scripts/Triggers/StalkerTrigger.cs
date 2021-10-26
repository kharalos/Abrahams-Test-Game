using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalkerTrigger : MonoBehaviour
{
    public GameObject stalker;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            stalker.SetActive(true);
            Destroy(gameObject);
        }
    }
}
