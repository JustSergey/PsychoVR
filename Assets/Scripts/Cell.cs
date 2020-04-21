using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public int X { get; private set; }
    public int Y { get; private set; }
    public int Z { get; private set; }
    public bool IsInfected { get; private set; }

    public void Set(int x, int y, int z)
    {
        X = x;
        Y = y;
        Z = z;
        IsInfected = false;
    }

    public void Infect()
    {
        Renderer renderer = gameObject.GetComponent<Renderer>();
        renderer.material.SetColor("_EmissionColor", new Color(0.4f, 0, 0));
        IsInfected = true;
    }

    public void Disinfect()
    {
        Renderer renderer = gameObject.GetComponent<Renderer>();
        renderer.material.SetColor("_EmissionColor", new Color(0, 0, 0));
        IsInfected = false;
    }
}
