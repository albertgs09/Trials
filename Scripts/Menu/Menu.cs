using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    AsyncOperation loadingOperation;
    public Slider progressBar;
    public GameObject menu, loadingScreen, titleScreen, controlScreen, credits;

    void Update()
    {
        if (loadingOperation != null)
        {
            float progressValue = Mathf.Clamp01(loadingOperation.progress / 0.9f);
            progressBar.value = Mathf.Clamp01(loadingOperation.progress / 0.9f);

        }

    }
    public void Play()
    {
        loadingScreen.SetActive(true);
        menu.SetActive(false);
       loadingOperation =  SceneManager.LoadSceneAsync("Forest");
    }

    public void StartGame()
    {
        titleScreen.SetActive(false);
        menu.SetActive(true);
    }

    public void Controls()
    {
        menu.SetActive(false);
        controlScreen.SetActive(true);
    }

    public void Credits()
    {
        menu.SetActive(false);
        credits.SetActive(true);
    }

    public void Back()
    {
        menu.SetActive(true);
        controlScreen.SetActive(false);
        credits.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
