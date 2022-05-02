using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAnimation : MonoBehaviour
{
    Animator anim;
    public bool isWalking = false;
    bool canRead;
    bool canPickUp;
    public GameObject torch;
    public ParticleSystem sparks;
    public AudioSource camAudio, soundEffectCam;
    public AudioClip wood, pageFlip;
    TimedDeath deathTime;
    public Light light;
    public GameManager gm;
    GameObject letter;
    public string pickUptext = "Press 'E' to pick up.";
    string readText = "Press 'E' to read.";
    public Text displayText;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        deathTime = GetComponent<TimedDeath>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetMouseButtonDown(0))// if has a torch
        {
            anim.SetTrigger("Swing");
        }


        CheckPickUp();
        CheckLetterTrigger();
    }

    void CheckPickUp()
    {
        if (canPickUp)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                torch.SetActive(true);
                gm.DisableText();
                soundEffectCam.clip = wood;
                soundEffectCam.Play();
            }
        }
    }
    void CheckLetterTrigger()
    {
        if (canRead)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if(letter != null)
                {
                    gm.DisplayLetter(letter.name);
                    gm.DisableText();
                    soundEffectCam.clip = pageFlip;
                    soundEffectCam.Play();
                }
               
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            gm.DisableLetter();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CampFire"))
        {
            if (torch.activeSelf == false)
            {
                gm.DisplayText(pickUptext);
                canPickUp = true;
            }
           
        }

        if (other.gameObject.CompareTag("SafeZone"))
        {
            camAudio.Stop();
            deathTime.Reset();
        }

        if (other.gameObject.CompareTag("DeathSpots"))
        {
            if (!torch.activeSelf)
            {
                deathTime.StartDeath();
            }
        }

        if (other.gameObject.CompareTag("Letters"))
        {
            letter = other.gameObject;
            canRead = true;
            gm.DisplayText(readText);
        }
       
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Letters"))
        {
            canRead = false;
            gm.DisableText();
        }
        if (other.gameObject.CompareTag("CampFire"))
        {
            gm.DisableText();
            canPickUp = false;
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Outside"))
        {
            light.range = 20;
        }

        if (other.gameObject.CompareTag("CryptBlock"))
        {
            displayText.enabled = true;
        }

        if (other.gameObject.CompareTag("House"))
        {
            light.range = 8;
        }
    }

    void OnCollisionExit(Collision other)
    {
       
        if (other.gameObject.CompareTag("CryptBlock"))
        {
            displayText.enabled = false;
        }
    }
   
}