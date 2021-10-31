using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaTrigger : MonoBehaviour
{
    public GameObject seraph;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(EnteredArena());
            GetComponent<BoxCollider>().enabled = false;
            Destroy(GetComponent<BoxCollider>());
        }
    }
    IEnumerator EnteredArena()
    {
        yield return new WaitForSeconds(14f);
        seraph.SetActive(true);
        yield return new WaitForSeconds(2f);
        FindObjectOfType<SubtitleManager>().AddSubtitles("<color=yellow>Come Abraham, fire won't harm you.</color>", 30f, false);
        Destroy(gameObject);
    }
}
