using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowText : MonoBehaviour
{
    public Animator anim;
    public string displayText = "";
    public Text dialogue;
   void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            anim.enabled = true;
            dialogue.text = displayText;
            Destroy(gameObject);
        }
    }
}
