using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalkerTrigger : MonoBehaviour
{
    public GameObject stalker,satan;
    public string[] texts;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            stalker.SetActive(true);
            satan.SetActive(true);
            foreach (string text in texts)
            {
                FindObjectOfType<SubtitleManager>().AddSubtitles(text, 4f, false);
            }
            Destroy(gameObject);
        }
    }
}
