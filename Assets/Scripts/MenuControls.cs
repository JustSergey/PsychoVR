using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuControls : MonoBehaviour
{
    public Slider WidthSlider;
    public Slider LengthSlider;
    public Slider HeightSlider;
    public Slider StreakSlider;
    public Slider InfectionChanceSlider;
    public Slider SpreadChanceSlider;
    public Slider PropagationTimeSlider;

    public void PlayPressed()
    {
        var settings = new WorldConfig
        {
            Size = new Vector3Int((int)LengthSlider.value, (int)WidthSlider.value, (int)HeightSlider.value),
            Streak = StreakSlider.value,
            RandomInfectionChance = InfectionChanceSlider.value,
            SpreadInfectionChance = SpreadChanceSlider.value,
            PropagationTime = PropagationTimeSlider.value
        };
        System.IO.File.WriteAllText(Application.dataPath + "/WorldSettings.json", JsonUtility.ToJson(settings));
        SceneManager.LoadScene("SampleScene");
    }
}
