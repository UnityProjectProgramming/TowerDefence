using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{

    [SerializeField] Waypoint startWaypoint;
    [SerializeField] Waypoint endWaypoint;

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };


	void Start ()
    {
        SetStartAndEndColors();
        LoadBlocks();
        ExploreNeighbours();
	}

    private void ExploreNeighbours()
    {
        foreach(Vector2Int direction in directions)
        {
            Vector2Int explorationCoordinates = direction + startWaypoint.GetGridPos();
            print("Exploring " + explorationCoordinates);
            grid[explorationCoordinates].SetTopColor(Color.blue);
        }
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
    }

    private void SetStartAndEndColors()
    {
        startWaypoint.SetTopColor(Color.green);
        endWaypoint.SetTopColor(Color.red);
    }
}
