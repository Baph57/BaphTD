using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targetEnemy;

    // Update is called once per frame
    void Update()
    {
        //LookAt is a Unity Method, obviously helps a lot
        objectToPan.LookAt(targetEnemy);
    }
}
