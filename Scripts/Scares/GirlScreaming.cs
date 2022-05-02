using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlScreaming : MonoBehaviour
{
    public GameObject screaming;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            screaming.SetActive(true);
            Destroy(gameObject);
        }
    }
}
