using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public float time;
    public string scene;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartTime(time));
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

   IEnumerator StartTime(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(scene);
    }
}
