using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//turn off script when not using
public class SettingsController : MonoBehaviour
{
    public Slider mSensitivitSlider;
    public FirstPersonAIO fpsScript;
    //maxValue = 15;

    float currentValue;
    // Start is called before the first frame update
    void Start()
    {
        mSensitivitSlider.value = fpsScript.mouseSensitivity;
    }

    // Update is called once per frame
    void Update()
    {
        fpsScript.mouseSensitivity = mSensitivitSlider.value;
    }
}
