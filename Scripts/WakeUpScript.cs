using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WakeUpScript : MonoBehaviour
{
    Animator anim;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(WakeUp(4));
    }

    IEnumerator WakeUp(float time)
    {
        yield return new WaitForSeconds(time);
        anim.enabled = true;
    }

    public void TurnOnPlayer()
    {
        player.SetActive(true);
        Destroy(gameObject);
    }
}
