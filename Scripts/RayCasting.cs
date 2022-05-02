using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayCasting : MonoBehaviour
{
    public float interactionDistance = 3;
    public GameObject reticle, Fire,witches, hangingWitch, buriedTorches, gallowTorch;
    public Sprite reticleHighlightedImage;
    public Sprite reticleDimmedImage;
    public Material offMaterial;
    public AudioClip offSound;
    public GameObject torch;
    public GameManager gm;
    public AudioSource scareAudio, soundEffectcam;
    public AudioClip scare1,scare2, bookSound;
    TimedDeath deathTime;
    PlayerAnimation pa;
    bool canPickUp;
    GameObject book;
    // Start is called before the first frame update
    void Start()
    {
        deathTime = GetComponent<TimedDeath>();
        pa = GetComponent<PlayerAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canPickUp)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                switch (book.name)
                {
                    case "Book1":
                        Book1();
                        break;
                    case "Book2":
                        Book2();
                        break;
                    case "Book3":
                        Book3();
                        break;
                }
                soundEffectcam.clip = bookSound;
                soundEffectcam.Play();
                gm.DisableText();
                Destroy(book);
            }
        }
    }
   
    private void ItemsPickedUp(GameObject items)
    {
        items.SetActive(false);
        // get audio source from terminal
        // audioSource = terminal.GetComponent<AudioSource>();

        // play offSound clip once from the audio source
        //audioSource.PlayOneShot(offSound);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Book"))
        {
            canPickUp = true;
            gm.DisplayText(pa.pickUptext);
            book = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Book"))
        {
            canPickUp = false;
            gm.DisableText();

        }
    }

    private void Book1()
    {
        gm.hasBook1 = true;
        scareAudio.clip = scare1;
        scareAudio.Play();
        Fire.SetActive(true);
        buriedTorches.SetActive(false);
        Destroy(Fire, 7);
        Destroy(witches, 7);
        StartCoroutine(TurnOffTorch(7));
    }

    private void Book2()
    {
        gm.hasBook2 = true;

    }

    private void Book3()
    {
        gm.hasBook3 = true;
        scareAudio.clip = scare2;
        scareAudio.Play();
        gallowTorch.SetActive(false);
        hangingWitch.SetActive(false);
        if(torch.activeSelf)
        {
            torch.SetActive(false);
            StartCoroutine(TurnOnTorch(1));
        }
        
    }
    public IEnumerator TurnOffTorch(float time)
    {
        yield return new WaitForSeconds(time);
        torch.SetActive(false);
        deathTime.StartDeath();
    }
    public IEnumerator TurnOnTorch(float time)
    {
        yield return new WaitForSeconds(time);
        torch.SetActive(true);
    }

}
