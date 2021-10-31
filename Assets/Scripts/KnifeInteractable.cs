using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeInteractable : InteractableObject
{
    public GameObject targetPos;
    public override void Interaction()
    {
        base.Interaction();
        if (GetComponent<Knife>().active)
        {
            GetComponent<Knife>().Activate();
            StartCoroutine(LerpPhysics());
        }
    }
    IEnumerator LerpPhysics()
    {
        for (int i = 0; i < 100; i++)
        {
            yield return new WaitForSeconds(0.01f);
            transform.position = Vector3.Lerp(transform.position, targetPos.transform.position, 0.5f);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetPos.transform.rotation, 0.5f);
        }
        transform.position = targetPos.transform.position;
        transform.rotation = targetPos.transform.rotation;
        gameObject.transform.SetParent(targetPos.transform.parent);
        GetComponent<BoxCollider>().enabled = false;
        Destroy(this);
    }

}
