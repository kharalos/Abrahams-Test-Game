using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnablerTrigger : MonoBehaviour
{
    public GameObject theObject;
    public bool EnableIt;
    public bool DestroyIt;
    public bool DestroySelf;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (theObject)
            {
                if (DestroyIt) Destroy(theObject);
                else theObject.SetActive(EnableIt);
            }
            if (DestroySelf) Destroy(gameObject);
            else Destroy(this);
        }
    }
}
