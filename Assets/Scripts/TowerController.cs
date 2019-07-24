using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targetEnemy;
    [SerializeField] float attackRange = 40f;
    [SerializeField] ParticleSystem ballisticsParticles;


    // Update is called once per frame
    void Update()
    {
        BallisticsController();
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
                print("enemy out of range");
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
