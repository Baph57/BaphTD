using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypointer : MonoBehaviour
{

    Vector2Int gridPosition;
    const int gridSize = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    public int GetGridSize()
    {
        return gridSize;
    }


    public Vector2 GetGridPosition()
    {
        gridPosition.x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize;
        //this isn't the real y plane
        gridPosition.y = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;
        return new Vector2Int(gridPosition.x, gridPosition.y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
