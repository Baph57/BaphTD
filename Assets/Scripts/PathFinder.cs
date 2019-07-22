using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    //Dictionary DataStructure, similar to objects in js
    Dictionary<Vector2Int, Waypointer> grid = new Dictionary<Vector2Int, Waypointer>();

    //creating a queue for our waypointers, another different data type!
    Queue<Waypointer> waypointQueue = new Queue<Waypointer>();


    //array of possible directions for navagation AI/pathfinding
    Vector2Int[] cardinalMovements =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    //state variable
    [SerializeField]bool isRunning = true; //todo make private



    //works amazingly well, seems C# and Unity work very closely together
    //The fact that we can serialize these, assign them in the editor
    //then come back and write code referencing those exact objects, is insane.
    [SerializeField] Waypointer startWaypoint, endWaypoint;

    

    // Start is called before the first frame update
    void Start()
    {
        LoadBlocks();
        PathFindingController();
    }

    private void PathFindingController()
    {
        waypointQueue.Enqueue(startWaypoint);

        while(waypointQueue.Count > 0 && isRunning)
        {
            var originSearch = waypointQueue.Dequeue();
            originSearch.blockHasBeenExplored = true;
            CalculatePossibleDirections(originSearch);
        }
        print("pathfinding done?");
    }

    private void CalculatePossibleDirections(Waypointer prevWaypoint)
    {
        if (!isRunning) { return; }

        if (prevWaypoint == endWaypoint)
        {
            print("stopping");
            isRunning = false;
        }

        foreach(Vector2Int possibleMove in cardinalMovements)
        {
            //looping and taking the StartWaypoint and setting it so it's grabbing
            //the actual coordinates instead of the integer values that represent the
            //arithmetic responsible (0,1) -> (3,4)
            Vector2Int explorationCoordinates = prevWaypoint.GetGridPosition() + possibleMove;
            //print("exploring " + explorationCoordinates);

            //using bracket notation, we can reference these coordinates in our dictionary
            //then finally set the color to blue to signify we are evaluating it's position
            //as a valid navigation path
            try
            {
                Waypointer neighbor = grid[explorationCoordinates];
                if (!neighbor.blockHasBeenExplored)
                {
                neighbor.SetTopColor(Color.blue);//todo move later
                waypointQueue.Enqueue(neighbor);
                print("Queueing Neighbor: " + neighbor);
                }
            }
            catch
            {
                print("doesn't exist!");
            }
        }
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
            else if (waypoint == startWaypoint || waypoint == endWaypoint)
            {
                grid.Add(gridPosition, waypoint);
                startWaypoint.SetTopColor(Color.magenta);
                endWaypoint.SetTopColor(Color.cyan);
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
