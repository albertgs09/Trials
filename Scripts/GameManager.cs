using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool hasBook1;
    public bool hasBook2;
    public bool hasBook3;
    public bool allBooksCollected;

    public AudioSource scream;

    public GameObject cryptBlock, letterCan;

    public Image letterImg;
    public Sprite letter1, letter2, letter3, letter4, letter5;
    public Text pickUpText, searchText, findAllBooks;
    public GameObject blood,pause, restart;

    public Text letterText;
    public string l1, l2, l3, l4, l5;

    public Animator firstText;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartScream(3));
    }

    // Update is called once per frame
    void Update()
    {
        if(hasBook1 && hasBook2 && hasBook3)
        {
            allBooksCollected = true;
            searchText.color = Color.green;
            findAllBooks.color = Color.green;
            cryptBlock.SetActive(false);
        }
        
    }

    public void DisplayLetter( string name)
    {
        string letter = name;

        switch (letter)
        {
            case "Book": letterImg.sprite = letter1; letterText.text = l1;
                break;
            case "Objectives": letterImg.sprite = letter2; letterText.text = l2;
                break;
            case "BurialBook": letterImg.sprite = letter3; letterText.text = l3;
                break;
            case "StrangeNoise": letterImg.sprite = letter4; letterText.text = l4;
                break;
            case "Crypt": letterImg.sprite = letter5; letterText.text = l5;
                break;
        }
        letterCan.SetActive(true);
    }

    public void DisableLetter()
    {
        letterCan.SetActive(false);
    }

    public void DisplayText(string name)
    {
        pickUpText.enabled = true;
        pickUpText.text = name;
    }

    public void DisableText()
    {
        pickUpText.enabled = false;
    }

    IEnumerator StartScream(float time)
    {
        yield return new WaitForSeconds(3);
        scream.Play();
        yield return new WaitForSeconds(4);
        firstText.enabled = true;
    }
    public void Splatter()
    {
        StartCoroutine(BloodSplat(9.03f));
    }

    IEnumerator BloodSplat(float time)
    {
        yield return new WaitForSeconds(time);
        blood.SetActive(true);

        yield return new WaitForSeconds(2);
        restart.SetActive(true);
        pause.SetActive(false);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

    }

    public void Restart()
    {
        SceneManager.LoadScene("Forest");
    }
}
