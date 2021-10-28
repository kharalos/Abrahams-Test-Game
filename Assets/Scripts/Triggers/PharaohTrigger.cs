using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PharaohTrigger : MonoBehaviour
{
    public PharaohController pc;
    public GameObject seraphHierarchy;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(seraphHierarchy) seraphHierarchy.SetActive(false);
            pc.Activate();
            Destroy(gameObject);
        }
    }
}
