using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnelinerTrigger : MonoBehaviour
{
    public string text;
    public float time;
    public bool purge;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<SubtitleManager>().AddSubtitles(text, time, purge);
            Destroy(this);
        }
    }
}
