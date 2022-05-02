using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatingWitch : MonoBehaviour
{
    public GameObject torch;
    AudioSource witchAudio;
    public AudioClip clip, heartBeat, scare;
    Animator anim;
    int i = 0;
    public GameObject player;
    public AudioSource camAudio, scareAudio;
    public TimedDeath deathTime;
    // Start is called before the first frame update
    void Start()
    {
        witchAudio = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            transform.LookAt(player.transform);
            witchAudio.clip = clip;
            witchAudio.loop = false;
            anim.SetTrigger("Scream");
            if(i == 0)
            {
                StartCoroutine(TurnOffTorch(1));
            }
            Destroy(gameObject, 5f);
        }
        
    }

    IEnumerator TurnOffTorch(float time)
    {
        i++;
        yield return new WaitForSeconds(time);
        witchAudio.Play();
       // scareAudio.clip = scare;
       // scareAudio.Play();

        yield return new WaitForSeconds(time);
        torch.SetActive(false);
        deathTime.StartDeath();
      
    }
}
