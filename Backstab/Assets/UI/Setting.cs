using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    public Slider sensitivity;

    void Start() {
        sensitivity.value = Globals.mouseSensitivity;
    }

    public void setSensitivity(float value) {
        Globals.mouseSensitivity = sensitivity.value;
    }
}
