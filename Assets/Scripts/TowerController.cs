using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    
    //instance variables
    //parameters of each tower
    [SerializeField] Transform objectToPan;
    [SerializeField] float attackRange = 40f;
    [SerializeField] ParticleSystem ballisticsParticles;

	//state of each tower
	Transform targetEnemy;





	// Update is called once per frame
	void Update()
    {
        AcquireTargetEnemy();
        BallisticsController();
    }

    private void AcquireTargetEnemy()
    {
        EnemyController[] sceneEnemies = FindObjectsOfType<EnemyController>();
        if(sceneEnemies.Length == 0) { return; }

        Transform closestEnemy = sceneEnemies[0].transform;

        foreach (EnemyController enemy in sceneEnemies)
        {
            closestEnemy = GetClosestEnemy(closestEnemy, enemy.transform);
        }
        targetEnemy = closestEnemy;
    }

    private Transform GetClosestEnemy(Transform farthestAlongEnemy, Transform iteratedEnemyFromScene)
    {
        float distanceFromCurrentTarget =
            Vector3.Distance(gameObject.transform.position, farthestAlongEnemy.position);
        float distanceFromProposedTarget =
            Vector3.Distance(gameObject.transform.position, iteratedEnemyFromScene.position);
        //print(distanceFromCurrentTarget + " \\ " + distanceFromProposedTarget);

        if(distanceFromCurrentTarget > distanceFromProposedTarget)
        {
            return iteratedEnemyFromScene;
        }
        else
        {
            return farthestAlongEnemy;
        }

    }

    private void BallisticsController()
    {
        //reference to the ballistics particles, .emission is needed to stop the emission
        var emissionReference = ballisticsParticles.emission;

        //if we have a reference to the target enemy...
        if (targetEnemy)
        {
            //evaluate distance from rotating turret head to target enemy, store in variable
            float distanceFromEnemyTarget =
                Vector3.Distance(targetEnemy.transform.position, objectToPan.transform.position);

            //if we are in range
            if (distanceFromEnemyTarget <= attackRange)
            {
                //LookAt is a Unity Method, obviously helps a lot
                objectToPan.LookAt(targetEnemy);
                //our ballisticsFX.emission system gets turned on
                emissionReference.enabled = true;
            }
            //out of range
            else if (distanceFromEnemyTarget > attackRange)
            {
                //print("enemy out of range");
                //ballisticsFX turned off
                emissionReference.enabled = false;
            }
            else
            {
                //hacky catch
                print("Shouldn't get here TowerController.cs");
            }

        }
        else
        {
            //final evaluation to ensure the turret evaluates to off with no enemy
            emissionReference.enabled = false;
            print("no enemy");
        }
    }
}
