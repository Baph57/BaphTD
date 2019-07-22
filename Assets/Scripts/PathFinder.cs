using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{

    Dictionary<Vector2Int, Waypointer> grid = new Dictionary<Vector2Int, Waypointer>();

    //works amazingly well, seems C# and Unity work very closely together
    //The fact that we can serialize these, assign them in the editor
    //then come back and write code referencing those exact objects, is insane.
    [SerializeField] Waypointer startWaypoint, endWayPoint;



    // Start is called before the first frame update
    void Start()
    {
        LoadBlocks();
    }

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypointer>();
        foreach(Waypointer waypoint in waypoints)
        {
            var gridPosition = waypoint.GetGridPosition();
            if (grid.ContainsKey(gridPosition))
            {
                Debug.LogWarning("Overlapped Block " + waypoint);
            }
            else if (waypoint == startWaypoint)
            {
                grid.Add(gridPosition, waypoint);
                startWaypoint.SetTopColor(Color.magenta);
                endWayPoint.SetTopColor(Color.cyan);
            }
            else
            {
                grid.Add(gridPosition, waypoint);
                waypoint.SetTopColor(Color.black);
            }
        }
        print(grid.Count);
    }

}
