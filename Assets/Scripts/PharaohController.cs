using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PharaohController : MonoBehaviour
{
    bool activated,pursuing;
    NavMeshAgent agent;
    Animator anim;
    GameObject player;
    Vector3 startpos;
    public AudioSource headSource, handSource, feetSource;
    public AudioClip[] clips;
    public GameObject light1, light2;
    public void Activate()
    {
        anim.SetTrigger("enrage");
        headSource.PlayOneShot(clips[1]);
        light1.SetActive(true);
        light2.SetActive(true);
    }
    void Move()
    {
        activated = true;
    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        player = FindObjectOfType<Controller>().gameObject;
        startpos = transform.position;
    }
    void Strike()
    {
        handSource.PlayOneShot(clips[5]);
        if ((player.transform.position - transform.position).magnitude < 2.5f)
        {
            FindObjectOfType<Controller>().PushBack(transform.position, 9); //Method divides the force by 10 so 10 means 20 meter, 1 is 2m and 100 is 200m
            headSource.PlayOneShot(clips[4]);
        }
    }
    void Step()
    {
        feetSource.PlayOneShot(clips[0]);
    }
    void Update()
    {
        if (activated && (player.transform.position - transform.position).magnitude < 40f)
        {
            agent.SetDestination(player.transform.position);
            pursuing = true;
        }
        else if (activated) { agent.SetDestination(startpos); pursuing = false; }
        if (activated && (player.transform.position - transform.position).magnitude < 3f)
        {
            anim.SetTrigger("attack");
        }
        else anim.ResetTrigger("attack");
        anim.SetFloat("velocity", agent.velocity.magnitude / agent.speed);
        if (!headSource.isPlaying && activated) {
            if (pursuing) headSource.PlayOneShot(clips[2]);
            else headSource.PlayOneShot(clips[3]); 
        }
    }
}
