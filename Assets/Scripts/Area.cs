﻿using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Area
{
    const float error = 0.999999f;

    Cell[,,] grid;
    List<Cell> infectedCells;
    Vector3Int size;

    public Area(Vector3Int size, float streak, GameObject cellPrefab, Transform parent)
    {
        this.size = size;
        grid = GenerateGrid(size, streak, cellPrefab, parent);
        infectedCells = new List<Cell>();
    }

    private Cell[,,] GenerateGrid(Vector3Int size, float streak, GameObject cellPrefab, Transform parent)
    {
        Cell[,,] grid = new Cell[size.x, size.y, size.z];
        Vector3 cellSize = cellPrefab.GetComponent<Renderer>().bounds.size;
        float offsetX = (float)(size.x - 1) / 2;
        float offsetZ = (float)(size.z - 1) / 2;
        for (int x = 0; x < size.x; x++)
        {
            for (int y = 0; y < size.y; y++)
            {
                for (int z = 0; z < size.z; z++)
                {
                    Quaternion rotation = cellPrefab.transform.rotation;
                    Vector3 position = new Vector3(
                        (x - offsetX) * (cellSize.x + streak),
                        y * (cellSize.y + streak),
                        (z - offsetZ) * (cellSize.z + streak));
                    GameObject gameObject = Object.Instantiate(cellPrefab, position + parent.position, rotation, parent);
                    Cell cell = gameObject.GetComponent<Cell>();
                    cell.Set(x, y, z);
                    grid[x, y, z] = cell;
                }
            }
        }
        return grid;
    }

    private void TryInfect(int x, int y, int z)
    {
        if (x >= 0 && x < size.x &&
            y >= 0 && y < size.y &&
            z >= 0 && z < size.z && !grid[x, y, z].IsInfected)
        {
            grid[x, y, z].Infect();
            infectedCells.Add(grid[x, y, z]);
        }
    }

    public void TryDisinfect(Cell cell)
    {
        if (infectedCells.Remove(cell))
            cell.Disinfect();
    }

    public void RandomInfection(float chance)
    {
        if (Random.value <= chance)
        {
            int x = (int)(Random.Range(0f, size.x) * error);
            int y = (int)(Random.Range(0f, size.y) * error);
            int z = (int)(Random.Range(0f, size.z) * error);
            TryInfect(x, y, z);
        }
    }

    public void SpreadInfection(float chance)
    {
        List<Cell> cells = new List<Cell>(infectedCells);
        foreach (Cell cell in cells)
            for (int x = cell.X - 1; x < cell.X + 2; x++)
                for (int y = cell.Y - 1; y < cell.Y + 2; y++)
                    for (int z = cell.Z - 1; z < cell.Z + 2; z++)
                        if (!(x == cell.X && y == cell.Y && z == cell.Z) && Random.value <= chance)
                            TryInfect(x, y, z);
    }
}
