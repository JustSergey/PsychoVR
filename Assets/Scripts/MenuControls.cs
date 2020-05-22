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
        var settings = new WorldConfig();

        settings.size = Convert.ToInt32(SizeSlider.value);
        settings.streak = Convert.ToSingle(Math.Round(StreakSlider.value, 2));
        settings.randomInfectionChance = Convert.ToSingle(Math.Round(InfectionChanceSlider.value, 2));
        settings.spreadInfectionChance = Convert.ToSingle(Math.Round(SpreadChanceSlider.value, 2));
        settings.propagationTime = Convert.ToSingle(Math.Round(PropagationTimeSlider.value, 2));

        System.IO.File.WriteAllText(Application.dataPath + "/WorldSettings.json" ,JsonUtility.ToJson(settings));

        SceneManager.LoadScene("SampleScene");
    }
}
