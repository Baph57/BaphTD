using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{



    [SerializeField] int amountOfHitsToMeetDeathCondition = 10;
    //[SerializeField] GameObject parent;
    [SerializeField] GameObject DeathFX;
    GarbageCollector garboCollector;

    void Start()
    {

        garboCollector = FindObjectOfType<GarbageCollector>();
        PathFinder pathfinder = FindObjectOfType<PathFinder>();
        List<Waypointer> path = pathfinder.GetWaypointers();
        StartCoroutine(WaypointReader(path));
        AddBoxColliderOnRuntime();

    }

    private void AddBoxColliderOnRuntime()
    {
        //gameObject.
        //GameObject childFrame = transform.Find("Enemy_A");
        //childFrame.AddComponent<BoxCollider>().isTrigger = false;

        print("collider added");
    }

    private void OnParticleCollision(GameObject other)
    {
        --amountOfHitsToMeetDeathCondition;
        if(amountOfHitsToMeetDeathCondition <= 0)
        {

            GameObject deathExplosion = Instantiate(DeathFX, transform.position, Quaternion.identity);
            //var garboCollector = FindObjectOfType(GarbageCollector);
            deathExplosion.transform.parent = garboCollector.transform;
            Destroy(gameObject);
        }
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
            yield return new WaitForSeconds(2f);
        }
        print("Ending Patrol SIR!");
    }

}
