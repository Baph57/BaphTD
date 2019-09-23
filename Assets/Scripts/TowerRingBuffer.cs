using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerRingBuffer : MonoBehaviour
{
    [SerializeField]
    public TowerController placeableTower;

    [SerializeField]
    public int placeableTowerLimit = 4;




    public void PlaceTower(Waypointer spaceToPlace)
    {
        var towerObjects = FindObjectsOfType<TowerController>();
        var towerPlacedCount = towerObjects.Length;

        if(towerPlacedCount >= placeableTowerLimit)
        {
            print("henlo darkness my old fren");
        }
        else
        {
            Instantiate(
            placeableTower, 
            spaceToPlace.transform.position, 
            Quaternion.identity
            );
        }
    }
}
