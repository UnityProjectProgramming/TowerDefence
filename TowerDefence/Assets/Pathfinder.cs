using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{

    [SerializeField] Waypoint startWaypoint;
    [SerializeField] Waypoint endWaypoint;

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();
    bool isRunning = true;


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
        Pathfind();
        //ExploreNeighbours();
	}

    private void Pathfind()
    {
        queue.Enqueue(startWaypoint);

        while(queue.Count > 0)
        {
            var searchCenter = queue.Dequeue();
            HaltIfEndPointFound(searchCenter);
        }

        print("Finished Pathfinding?");
    }

    private void HaltIfEndPointFound(Waypoint searchCenter)
    {
        if (searchCenter == endWaypoint)
        {
            print("Goal Found");
            isRunning = false;
        }
    }

    private void ExploreNeighbours()
    {
        foreach(Vector2Int direction in directions)
        {
            Vector2Int explorationCoordinates = direction + startWaypoint.GetGridPos();
            print("Exploring " + explorationCoordinates);
            try
            {
                grid[explorationCoordinates].SetTopColor(Color.blue);
            }
            catch(Exception e)
            {
                print(e.Message);
            }
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
