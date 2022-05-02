using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChasingWitch : MonoBehaviour
{
    NavMeshAgent agent;
    Animator anim;
    GameObject player;
    bool chase;
    int i;
    SphereCollider col;
    AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
        col = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (chase)
        {
            anim.SetBool("IsWalking", true);
            agent.SetDestination(player.transform.position);
        }
       
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            col.enabled = false;
                anim.SetTrigger("Scream");
            audio.Play();
                transform.LookAt(player.transform);
                StartCoroutine(Scream(2));         
        }
    }

    IEnumerator Scream(float time)
    {
        yield return new WaitForSeconds(time);
        chase = true;
    }
}
