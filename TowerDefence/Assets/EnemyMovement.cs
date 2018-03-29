using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    [SerializeField] List<Waypoint> path;

	void Start ()
    {

    }
	

    IEnumerator PrintAllWaypoints()
    {
        print("Starting Patrol");
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            print("Visiting Block: " + waypoint);
            yield return new WaitForSeconds(1.0f);
        }
        print("End Patrol");
    }

    void Update ()
    {
	}
}
