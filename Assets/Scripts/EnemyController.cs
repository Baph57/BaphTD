using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [SerializeField] List<Waypointer> EnemyPath;
    // Start is called before the first frame update
    void Start()
    {
        //Co-routines allow us to have spaced out function calls without string refs

        StartCoroutine(WaypointReader());

    }

    IEnumerator WaypointReader() //co-routine
    {
        //reference to every block in the enemy path 
        foreach (Waypointer waypoint in EnemyPath)
        {
            transform.position = waypoint.transform.position;
            //yield 
            yield return new WaitForSeconds(1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
