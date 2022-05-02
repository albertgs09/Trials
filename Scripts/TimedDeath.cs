using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class TimedDeath : MonoBehaviour
    {
        public bool startTime;
        public float currentTime;
    float startingTime;
    public AudioSource camAudio;
    public AudioClip heartBeat;
    public GameObject death, runText;
    public GameManager gm;

    private void Start()
    {
        startingTime = currentTime;
    }
    // Update is called once per frame
    void Update()
        {
            if (startTime)
            {
                currentTime -= Time.deltaTime;
            }

            if (currentTime < 0)
            {
            //player dies
            Death();

                startTime = false;
                Time.timeScale = 0;
                Debug.Log("DEAD");
            camAudio.Stop();
            }
        }

    public void Reset()
    {
        runText.SetActive(false);
        startTime = false;
        currentTime = startingTime;
    }

    public void StartDeath()
    {
        startTime = true;
        runText.SetActive(true);
        StartCoroutine(Display(2));
        camAudio.clip = heartBeat;
        camAudio.Play();
        camAudio.loop = true;
    }

    void Death()
    {
        runText.SetActive(false);
        gm.Splatter();
        Instantiate(death, this.transform.position, this.transform.rotation);
        gameObject.SetActive(false);
    }

   IEnumerator Display(float time)
    {
        yield return new WaitForSeconds(time);
        runText.SetActive(false);
    }
}

