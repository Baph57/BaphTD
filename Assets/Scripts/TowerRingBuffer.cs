using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerRingBuffer : MonoBehaviour
{
    [SerializeField]
    public GameObject placeableTower;

    [SerializeField]
    public int placeableTowerLimit;

    public void PlaceTower(Waypointer spaceToPlace)
    {
        Instantiate(
                    placeableTower, 
                    spaceToPlace.transform.position, 
                    Quaternion.identity
                    );
    }
}
