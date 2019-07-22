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
        print("GridPos x:" + gridPosition.x + " ||  y:" + gridPosition.y);
        return new Vector2Int(gridPosition.x, gridPosition.y);
    }

    public void DisplayCoordTextMesh()
    {
        //label on top of box for coordinates
        TextMesh coordinateTextMesh = GetComponentInChildren<TextMesh>();
        string editorTextLabel = gridPosition.x / gridSize + "," + gridPosition.y / gridSize;
        coordinateTextMesh.text = editorTextLabel;

        //fairly self documenting, but labels the cube in the editor with coords
        gameObject.name = editorTextLabel;
    }
}
