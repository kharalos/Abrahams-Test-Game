using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonController : MonoBehaviour
{
    public GameObject player, front1,front2,front3,leftWh,rightWh;
    private Rigidbody body;
    bool whispering;
    Transform target;
    void Start()
    {
        if (ProgressionSaver.Instance.level > 1) GetComponent<AudioSource>().Stop();
        body = GetComponent<Rigidbody>();
        StartCoroutine(MoveAround(5f));
        target = front2.transform;
    }

    // Update is called once per frame
    void Update()
    {
        MoveToTarget(target.position);
        transform.LookAt(player.transform.position);
    }
    IEnumerator MoveAround(float time)
    {
        yield return new WaitForSeconds(time);
        if (whispering) StartCoroutine(MoveAround(5f));
        else
        {
            int i = Random.Range(1, 4);
            switch (i)
            {
                case 1:
                    target = front1.transform;
                    break;
                case 2:
                    target = front2.transform;
                    break;
                case 3:
                    target = front3.transform;
                    break;
            }
            StartCoroutine(MoveAround(Random.Range(0,10)));
        }
    }
    void MoveToTarget(Vector3 targetPosition)
    {
        transform.position = transform.position + ((targetPosition - transform.position) * 2 * Time.deltaTime);
    }
}
