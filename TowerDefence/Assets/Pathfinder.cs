using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour {

    Dictionary<Vector3Int, Waypoint> grid = new Dictionary<Vector3Int, Waypoint>();
   
	void Start ()
    {
        LoadBlocks();
	}

    private void LoadBlocks()
    {
        Waypoint[] waypoints = FindObjectsOfType<Waypoint>();

        foreach (Waypoint waypoint in waypoints)
        {
            var gridPos = waypoint.GetGridPos();
            // Add them to the dictionary
            if (grid.ContainsKey(gridPos))
            {
                Debug.LogWarning("Skipping Overlapping Block: " + waypoint);
            }
            else
            {
                grid.Add(gridPos, waypoint);
            }
        }
        print(grid.Count);
    }

    void Update ()
    {
		
	}
}
