using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PharaohController : MonoBehaviour
{
    bool activated;
    NavMeshAgent agent;
    Animator anim;
    GameObject player;
    Vector3 startpos;
    public void Activate()
    {
        anim.SetTrigger("enrage");
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
        if ((player.transform.position - transform.position).magnitude < 2.5f)
        {
            FindObjectOfType<Controller>().PushBack(transform.position, 100f);
        }
    }
    void Update()
    {
        if (activated && (player.transform.position - transform.position).magnitude < 15f)
        {
            agent.SetDestination(player.transform.position);
        }
        else if (activated) agent.SetDestination(startpos);
        if (activated && (player.transform.position - transform.position).magnitude < 3f)
        {
            anim.SetTrigger("attack");
        }
        else anim.ResetTrigger("attack");
        anim.SetFloat("velocity", agent.velocity.magnitude / agent.speed);
    }
}
