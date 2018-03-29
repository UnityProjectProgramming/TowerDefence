using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour {

    Vector3Int gridPos;

    const int GRID_SIZE = 10;


    public int GetGridSize()
    {
        return GRID_SIZE;
    }

    public Vector3Int GetGridPos()
    {
        return new Vector3Int(gridPos.x = Mathf.RoundToInt(transform.position.x / GRID_SIZE), 0, Mathf.RoundToInt(transform.position.z / GRID_SIZE));                         
    }
}
