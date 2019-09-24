using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerRingBuffer : MonoBehaviour
{
    [SerializeField]
    public TowerController placeableTower;

    [SerializeField]
    public int placeableTowerLimit = 4;

    //our ring buffer is actually a queue at the end of the day
    Queue<TowerController> ringBuffer = new Queue<TowerController>();


    public void PlaceTower(Waypointer spaceToPlace)
    {
        int towerPlacedCount = ringBuffer.Count;

        if(towerPlacedCount >= placeableTowerLimit)
        {
            RequeueExistingTower(spaceToPlace);
        }
        else
        {
            InstantiateNewTower(spaceToPlace);
        }
    }

    private void InstantiateNewTower(Waypointer spaceToPlace)
    {
        TowerController newTower = Instantiate(placeableTower, spaceToPlace.transform.position, Quaternion.identity);
        TowerRingBuffer hierarchyTidier = FindObjectOfType<TowerRingBuffer>();
        newTower.transform.parent = hierarchyTidier.transform;
        newTower.blockThatTowerOccupies = spaceToPlace;
        spaceToPlace.isPlayerInteractive = false;
        ringBuffer.Enqueue(newTower);
    }

    private void RequeueExistingTower(Waypointer newSpaceToPlace)
    {
        //initializing logic preparing to move tower that has been placed
        TowerController oldestTower = ringBuffer.Dequeue();
        oldestTower.blockThatTowerOccupies.isPlayerInteractive = true;
        newSpaceToPlace.isPlayerInteractive = false;

        //now that the tower is ready to move, we initialize values/properties
        oldestTower.blockThatTowerOccupies = newSpaceToPlace;
        oldestTower.transform.position = newSpaceToPlace.transform.position;
        ringBuffer.Enqueue(oldestTower);
        print("henlo darkness my old fren");
    }
}
