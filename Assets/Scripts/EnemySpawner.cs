using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] int numberOfEnemiesToSpawn = 10;
    [Range(1f, 60f)]
    [SerializeField] float secondsBetweenSpawns = 2f;
    [SerializeField] GameObject enemyNPC;
    List<GameObject> listOfEnemies;

    //StartCoroutine(WaypointReader(path));
    //List<Waypointer> path = pathfinder.GetWaypointers();

    // Start is called before the first frame update
    void Start()
    {
        //for(int i = 0; i < numberOfEnemiesToSpawn; i++)
        //{
        //    listOfEnemies.Add(enemyNPC);
        //}
        //StartCoroutine(EnemySpawningExecutor(listOfEnemies));
        StartCoroutine(SimpleEnemySpawner());


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SimpleEnemySpawner()
    {
        while(true)
        {
            Instantiate(enemyNPC, transform);
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }

    //IEnumerator is essentially a Co-Routine
    IEnumerator EnemySpawningExecutor(List<GameObject> enemyNPCs) //co-routine
    {
        print("Spawning!");
        foreach (GameObject enemy in enemyNPCs)
        {
            //Instantiate(enemy, transform.position, Quaternion.identity);
            Instantiate(enemy, transform);
            //yield says to wait for the next loop iteration until the yield
            //resolves essentially. WaitForSeconds is available thru Unity.API
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
        print("Ending spawning!");
    }

}
