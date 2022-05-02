using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicTrigger : MonoBehaviour
{
    public GameObject player, cinematicCam, pause, light, witches;



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = other.gameObject;
            player.SetActive(false);
            cinematicCam.SetActive(true);
            pause.SetActive(false);
            witches.SetActive(true);
            light.SetActive(true);
            Destroy(gameObject);
        }
    }
}
