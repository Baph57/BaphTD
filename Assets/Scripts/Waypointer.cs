using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypointer : MonoBehaviour
{

    public bool blockHasBeenExplored = false; //ok as is, as data class

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


    public Vector2Int GetGridPosition()
    {
        gridPosition.x = Mathf.RoundToInt(transform.position.x / gridSize);
        //this isn't the real y plane
        gridPosition.y = Mathf.RoundToInt(transform.position.z / gridSize);
        //print("GridPos x:" + gridPosition.x + " ||  y:" + gridPosition.y);
        return new Vector2Int(gridPosition.x, gridPosition.y);
    }

    public void DisplayCoordTextMesh()
    {
        //label on top of box for coordinates
        TextMesh coordinateTextMesh = GetComponentInChildren<TextMesh>();
        string editorTextLabel = gridPosition.x + "," + gridPosition.y;
        coordinateTextMesh.text = editorTextLabel;

        //fairly self documenting, but labels the cube in the editor with coords
        gameObject.name = editorTextLabel;
    }

    public void SetTopColor(Color color)
    {
        MeshRenderer topBlockMeshRenderer = transform.Find("Y+Plane").GetComponent<MeshRenderer>();
        //print(transform.Find("Y+Plane").GetComponent<MeshRenderer>());
        topBlockMeshRenderer.material.color = color;
    }   
}
