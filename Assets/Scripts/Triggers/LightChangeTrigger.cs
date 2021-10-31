using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightChangeTrigger : MonoBehaviour
{
    public LightChangeTrigger otherTrigger;
    public Light fener;
    public bool lightsOut;
    public bool first;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (otherTrigger.first && !lightsOut) StartCoroutine(LightsOut());
            if (first) LightsBack();
        }
    }
    IEnumerator LightsOut()
    {
        lightsOut = true;
        for (float i = 10; i > 0; i -= 0.1f)
        {
            yield return new WaitForSeconds(0.05f);
            fener.intensity = i;
        }
        fener.intensity = 0;
    }
    void LightsBack()
    {
        fener.intensity = 10;
        lightsOut = false;
    }
}
