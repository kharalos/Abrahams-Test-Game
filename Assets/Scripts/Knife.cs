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
    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
        anim = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
        situations = 0;
    }
    private void Update()
    {
        if (Input.GetButtonUp("Fire1") && active)
        {
            anim.SetTrigger("Stab");
        }
    }
    public void Activate()
    {
        gm.hasKnife = true;
        active = true;
        source.PlayOneShot(clips[0]);
    }
    void KnifeHigh()
    {
        if (situations == 1)
        {
            anim.speed = 0;
            anim.SetTrigger("Interrupt");
            anim.ResetTrigger("Stab");
        }
    }
    public void RegainControl()
    {
        anim.speed = 1;
    }
    void Stab()
    {
        source.PlayOneShot(clips[1]);
        if(situations == 2)
        {
            gm.GoodEnding();
        }
        if(situations == 3)
        {
            gm.BadEnding();
        }
        situations = 0;
    }
    public void ChangeSituation(int value) {
        situations = value;
    }
}
