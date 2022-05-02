using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject pause, pauseMenu, controls;
    public string scene;
    bool isPaused = false;
    SettingsController sc;
    // Start is called before the first frame update
    void Start()
    {
        sc = GetComponent<SettingsController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }

        if (isPaused)
        {
            pause.SetActive(true);
            sc.enabled = true;
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = isPaused;
        }
        else
        {
            pause.SetActive(false);
            Time.timeScale = 1;
            sc.enabled = false;
            Cursor.visible = isPaused;
            Cursor.lockState = CursorLockMode.Locked;

        }
    } 

    public void Resume()
    {
        isPaused = false;
    }

    public void Back()
    {
        pauseMenu.SetActive(true);
        controls.SetActive(false);
    }

    public void Controls()
    {
        pauseMenu.SetActive(false);
        controls.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(scene);
    }

    public void Quit()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
