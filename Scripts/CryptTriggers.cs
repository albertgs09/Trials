using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CryptTriggers : MonoBehaviour
{
    public GameObject magicEffects, books, broom, torch, witches, audio, witch, death;
    public bool hasBroom, canPlaceBooks, canGrabBroom, canPlaceBroom;
    GameObject broomCollider, cryptCollider;
    public Animator textAnim;
    public CryptSceneController gm;
    void Update()
    {
        if (canPlaceBooks)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                books.SetActive(true);
            }
        }

        if (canGrabBroom)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                hasBroom = true;
                Destroy(broomCollider);
            }
        }

        if (canPlaceBroom)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                broom.SetActive(true);
                magicEffects.SetActive(true);
                Destroy(cryptCollider);
                audio.SetActive(true);
                torch.SetActive(false);
                StartCoroutine(ActivateWitches(5));
            }
           
        }
    }

    IEnumerator ActivateWitches(float time)
    {
        yield return new WaitForSeconds(time);
        magicEffects.SetActive(false);
        witches.SetActive(true);
        books.SetActive(false);
        broom.SetActive(false);
        witch.SetActive(true);

        yield return new WaitForSeconds(time + 2);
        magicEffects.SetActive(true);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("WitchCrypt"))
        {
            if (hasBroom)
            {
                canPlaceBroom = true;
                cryptCollider = other.gameObject;
            }
            canPlaceBooks = true;
        }

        if (other.gameObject.CompareTag("Broom"))
        {
           
            canGrabBroom = true;
            broomCollider = other.gameObject;
        }
        if (other.gameObject.name == "TorchOff")
        {
            textAnim.enabled = true;
            Destroy(other.gameObject);
            StartCoroutine(TorchOff(3));
        }

        if (other.gameObject.name == "TooClose")
        {
            Death();
        }

    } 
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("WitchCrypt"))
        {
            canPlaceBooks = false;
        }

        if (other.gameObject.CompareTag("Broom"))
        {
            canGrabBroom = false;
        }
       
    }

    IEnumerator TorchOff(float time)
    {
        yield return new WaitForSeconds(time);
        torch.SetActive(false);
    }

    void Death()
    {
        gm.Splatter();
        Instantiate(death, this.transform.position, this.transform.rotation);
        gameObject.SetActive(false);
    }
}
