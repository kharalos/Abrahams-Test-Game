using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{

    Animator anim;
    GameManager gm;
    public bool active;
    public AudioClip[] clips;
    AudioSource source;
    public int situations;
    public Situation ishmael;
    public GameObject seraph;
    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
        anim = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
        situations = 0;
    }
    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && active)
        {
            anim.SetTrigger("Stab");
        }
    }
    public void Activate()
    {
        gm.hasKnife = true;
        active = true;
    }
    public void PlayGrabSound()
    {
        source.PlayOneShot(clips[0]);
    }
    void KnifeHigh()
    {
        if (situations == 1)
        {
            anim.speed = 0;
            anim.SetTrigger("Interrupt");
            anim.ResetTrigger("Stab");
            active = false;
            ishmael.situationID = 0;
            situations = 0;
            seraph.SetActive(true);
            StartCoroutine(RegainControl());
        }
        else source.PlayOneShot(clips[1]);
    }
    IEnumerator RegainControl()
    {
        FindObjectOfType<SubtitleManager>().AddSubtitles("<color=red>Stop!</color>", 1f, true);
        FindObjectOfType<SubtitleManager>().AddSubtitles("<color=yellow>Your lord has granted you this sheep to sacrifice instead.</color>", 3f, false);
        FindObjectOfType<SubtitleManager>().AddSubtitles("<color=green>You passed the test Abraham.</color>", 2f, false);
        yield return new WaitForSeconds(2f);
        ishmael.situationID = 3;
        anim.speed = 1;

             active = true;
    }
    void Stab()
    {

        if(situations == 2)
        {
            source.PlayOneShot(clips[2]);
            gm.GoodEnding();
        }
        if(situations == 3)
        {
            source.PlayOneShot(clips[2]);
            gm.BadEnding();
        }
        situations = 0;
    }
    public void ChangeSituation(int value) {
        situations = value;
    }
}
