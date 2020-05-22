using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuControls : MonoBehaviour
{
    public Slider SizeSlider;
    public Slider StreakSlider;
    public Slider InfectionChanceSlider;
    public Slider SpreadChanceSlider;
    public Slider PropagationTimeSlider;

    public void PlayPressed()
    {
        var settings = new WorldConfig
        {
            //Size = (int)SizeSlider.value,
            Streak = StreakSlider.value,
            RandomInfectionChance = InfectionChanceSlider.value,
            SpreadInfectionChance = SpreadChanceSlider.value,
            PropagationTime = PropagationTimeSlider.value
        };
        System.IO.File.WriteAllText(Application.dataPath + "/WorldSettings.json", JsonUtility.ToJson(settings));
        SceneManager.LoadScene("SampleScene");
    }
}
