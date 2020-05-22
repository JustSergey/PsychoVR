using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    private int Size;
    private float Streak;
    public GameObject CellPrefab;
    private float RandomInfectionChance;
    private float SpreadInfectionChance;
    private float PropagationTime;
    Area area;

    void Start()
    {
        var worldConfig = new WorldConfig();
        string configJSON = System.IO.File.ReadAllText(Application.dataPath + "/WorldSettings.json");
        worldConfig = JsonUtility.FromJson<WorldConfig>(configJSON);
        SetParams(worldConfig);

        area = new Area(Size, Streak, CellPrefab, transform);
        area.RandomInfection(1.0f);
        StartCoroutine(Infection());
    }

    IEnumerator Infection()
    {
        while (true)
        {
            yield return new WaitForSeconds(PropagationTime);
            area.RandomInfection(RandomInfectionChance);
            area.SpreadInfection(SpreadInfectionChance);
        }
    }

    public void Disinfect(Cell cell)
    {
        area.TryDisinfect(cell);
    }

    private void SetParams(WorldConfig config)
    {
        Size = config.size;
        Streak = config.streak;
        RandomInfectionChance = config.randomInfectionChance;
        SpreadInfectionChance = config.spreadInfectionChance;
        PropagationTime = config.propagationTime;
    }
}
