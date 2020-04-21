using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    public int Size;
    public float Streak;
    public GameObject CellPrefab;
    public float RandomInfectionChance;
    public float SpreadInfectionChance;
    public float PropagationTime;
    Area area;

    void Start()
    {
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
}
