using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CryptCam : MonoBehaviour
{
   public void NextScene()
    {
        //fire scene
        SceneManager.LoadScene("FireScene");
    }
}
