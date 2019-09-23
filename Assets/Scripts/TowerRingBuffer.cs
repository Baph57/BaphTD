using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerRingBuffer : MonoBehaviour
{
    [SerializeField]
    public GameObject placeableTower;

    [SerializeField]
    public int placeableTowerLimit = 4;

    private int numberOfTowersPlaced = 0;

    // private Queue<GameObject> circularBuffer;



    public void PlaceTower(Waypointer spaceToPlace)
    {
        if(numberOfTowersPlaced == placeableTowerLimit)
        {
            print("henlo darkness my old fren");
        }
        else
        {
            numberOfTowersPlaced++;
            var towerToPlace = Instantiate(
            placeableTower, 
            spaceToPlace.transform.position, 
            Quaternion.identity
            );
            // circularBuffer.Enqueue(towerToPlace);
        }
    }
}
