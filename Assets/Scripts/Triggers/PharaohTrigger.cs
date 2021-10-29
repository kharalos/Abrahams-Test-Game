using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PharaohTrigger : MonoBehaviour
{
    public PharaohController pc;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            pc.Activate();
            Destroy(gameObject);
        }
    }
}
