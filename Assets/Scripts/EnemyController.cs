using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    //[SerializeField] List<Waypointer> EnemyPath;
    // Start is called before the first frame update
    void Start()
    {

        PathFinder pathfinder = FindObjectOfType<PathFinder>();
        List<Waypointer> path = pathfinder.GetWaypointers();
        StartCoroutine(WaypointReader(path));

    }

    //IEnumerator is essentially a Co-Routine
    IEnumerator WaypointReader(List<Waypointer> waypoints) //co-routine
    {
        print("Starting Patrol SIR!");
        //reference to every block in the enemy path 
        foreach (Waypointer waypoint in waypoints)
        {
            transform.position = waypoint.transform.position;
            //yield says to wait for the next loop iteration until the yield
            //resolves essentially. WaitForSeconds is available thru Unity.API
            //print("Patrol Pos: " + waypoint.name);
            yield return new WaitForSeconds(1f);
        }
        print("Ending Patrol SIR!");
    }

}
