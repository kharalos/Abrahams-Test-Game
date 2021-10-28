using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeraphTrigger : MonoBehaviour
{
    public GameObject seraphHierarchy;
    public string text1, text2;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            seraphHierarchy.SetActive(true);
            SubtitleManager sm = FindObjectOfType<SubtitleManager>();
            sm.AddSubtitles(text1, 4f, true);
            sm.AddSubtitles(text2, 6f, false);
            Destroy(gameObject);
        }
    }
}
