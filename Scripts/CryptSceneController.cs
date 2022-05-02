using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CryptSceneController : MonoBehaviour
{

    public GameObject restart, pause, blood;

    public void Splatter()
    {
        StartCoroutine(BloodSplat(3f));
    }

    IEnumerator BloodSplat(float time)
    {
        yield return new WaitForSeconds(time);
        blood.SetActive(true);

        yield return new WaitForSeconds(1);
        restart.SetActive(true);
        pause.SetActive(false);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

    }

    public void Restart()
    {
        SceneManager.LoadScene("InToTheCrypt");
    }
}
