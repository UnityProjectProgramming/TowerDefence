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
    Waypoint searchCenter;

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

        while(queue.Count > 0 && isRunning)
        {
            searchCenter = queue.Dequeue();
            HaltIfEndPointFound();
            ExploreNeighbours();
            searchCenter.isExplored = true;
        }

        print("Finished Pathfinding?");
    }

    private void HaltIfEndPointFound()
    {
        if (searchCenter == endWaypoint)
        {
            print("Goal Found");
            isRunning = false;
        }
    }

    private void ExploreNeighbours()
    {
        if (!isRunning) { return; }
        foreach(Vector2Int direction in directions)
        {
            Vector2Int neighbourCoordinates = direction + searchCenter.GetGridPos();
            try
            {
                QueueNewNeighbours(neighbourCoordinates);
            }
            catch (Exception e)
            {
                print(e.Message);
            }
        }
    }

    private void QueueNewNeighbours(Vector2Int neighbourCoordinates)
    {
        Waypoint neigbhour = grid[neighbourCoordinates];
        if(neigbhour.isExplored || queue.Contains(neigbhour))
        {
            // do nothing..
        }
        else
        {
            queue.Enqueue(neigbhour);
            neigbhour.exploredFrom = searchCenter;
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
