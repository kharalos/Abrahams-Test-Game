using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeraphController : MonoBehaviour
{
    public GameObject target;
    void Update()
    {
        transform.LookAt(Camera.main.transform);
        MoveToTarget(target.transform.position);
    }
    void MoveToTarget(Vector3 targetPosition)
    {
        transform.position = transform.position + ((targetPosition - transform.position) * 2 * Time.deltaTime);
    }
}
