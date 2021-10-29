using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointTrigger : MonoBehaviour
{
    public int newLevel;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ProgressionSaver.Instance.NewLevel(newLevel);
            Debug.Log("Checkpoint reached. Level: " + newLevel);
            Destroy(this);
        }
    }
}
