using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightChangeTrigger : MonoBehaviour
{
    public LightChangeTrigger otherTrigger;
    public Controller controller;
    public bool entered;
    public bool first;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            entered = true;
            if (otherTrigger.first) LightsOut();
        }
    }
    void LightsOut()
    {

    }
    void LightsBack()
    {

    }
}
