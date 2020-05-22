using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderSystem : MonoBehaviour
{
    public Slider slider;
    public Text text;

    void Update()
    {
        text.text = Math.Round(slider.value, 2).ToString();
    }
}
