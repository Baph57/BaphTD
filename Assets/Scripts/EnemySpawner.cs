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

    void Start()
    {
        //TODO: implement a limited amount of enemies
        StartCoroutine(SimpleEnemySpawner());

    }
    IEnumerator SimpleEnemySpawner()
    {
        while(true)
        {
            Instantiate(enemyNPC, transform);
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }

    //TODO: implement limited amounts of enemies spawning
    IEnumerator EnemySpawningExecutor(List<GameObject> enemyNPCs) 
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
