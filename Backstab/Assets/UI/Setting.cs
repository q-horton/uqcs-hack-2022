using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    public Slider sensitivity;

    public float sen;

    void Update() {
        sen = Globals.mouseSensitivity;
    }

    public void setSensitivity(float value) {
        Globals.mouseSensitivity = sensitivity.value;
    }
}
