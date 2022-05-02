using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour
{
    public GameManager gm;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("CryptBlock") && !gm.allBooksCollected)
        {
            //Text- Collect all books before proceeding
            Debug.Log("Collect all Books");
        }
    }

}
