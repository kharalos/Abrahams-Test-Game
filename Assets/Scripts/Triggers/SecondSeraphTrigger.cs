using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondSeraphTrigger : MonoBehaviour
{
    public SeraphController sc;
    public GameObject target;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            sc.target = target;
            Destroy(this);
        }
    }
}
