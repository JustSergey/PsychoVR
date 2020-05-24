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

    void Start()
    {
        string json = System.IO.File.ReadAllText(Application.dataPath + "/WorldSettings.json");
        WorldConfig config = JsonUtility.FromJson<WorldConfig>(json);
        LengthSlider.value = config.Size.x;
        WidthSlider.value = config.Size.y;
        HeightSlider.value = config.Size.z;
        StreakSlider.value = config.Streak;
        InfectionChanceSlider.value = config.RandomInfectionChance;
        SpreadChanceSlider.value = config.SpreadInfectionChance;
        PropagationTimeSlider.value = config.PropagationTime;
    }

    public void PlayPressed()
    {
        var config = new WorldConfig
        {
            Size = new Vector3Int((int)LengthSlider.value, (int)WidthSlider.value, (int)HeightSlider.value),
            Streak = StreakSlider.value,
            RandomInfectionChance = InfectionChanceSlider.value,
            SpreadInfectionChance = SpreadChanceSlider.value,
            PropagationTime = PropagationTimeSlider.value
        };
        System.IO.File.WriteAllText(Application.dataPath + "/WorldSettings.json", JsonUtility.ToJson(config));
        SceneManager.LoadScene("SampleScene");
    }
}
