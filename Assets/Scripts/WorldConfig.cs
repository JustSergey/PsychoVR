using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WorldConfig
{
    public Vector3Int Size;
    public float Streak;
    public float RandomInfectionChance;
    public float SpreadInfectionChance;
    public float PropagationTime;
}
