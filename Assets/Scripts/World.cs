using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    private Vector3Int size;
    private float streak;
    private float randomInfectionChance;
    private float spreadInfectionChance;
    private float propagationTime;
    private Area area;

    public GameObject CellPrefab;

    void Start()
    {
        string json = System.IO.File.ReadAllText(Application.dataPath + "/WorldSettings.json");
        WorldConfig config = JsonUtility.FromJson<WorldConfig>(json);
        SetParams(config);

        area = new Area(size, streak, CellPrefab, transform);
        area.RandomInfection(1.0f);
        StartCoroutine(Infection());
    }

    private void SetParams(WorldConfig config)
    {
        size = config.Size;
        streak = config.Streak;
        randomInfectionChance = config.RandomInfectionChance;
        spreadInfectionChance = config.SpreadInfectionChance;
        propagationTime = config.PropagationTime;
    }

    IEnumerator Infection()
    {
        while (true)
        {
            yield return new WaitForSeconds(propagationTime);
            area.RandomInfection(randomInfectionChance);
            area.SpreadInfection(spreadInfectionChance);
        }
    }

    public void Disinfect(Cell cell)
    {
        area.TryDisinfect(cell);
    }
}
