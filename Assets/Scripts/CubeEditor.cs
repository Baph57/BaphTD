using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
//SelectionBase means that whatever the script is attached to is the "default" item/prefab
//to grab when clicked on in the editor
[SelectionBase]
[RequireComponent(typeof(Waypointer))]

public class CubeEditor : MonoBehaviour
{
    //refactoring to have Waypointer not rely on CubeEditor
    // [Range(1f, 20f)][SerializeField] float gridSize = 10f;



    //instance variables
    Vector3 snapPosition;
    Waypointer waypointer;

    //member variables
    int gridSize;



    private void Awake()
    {
        waypointer = GetComponent<Waypointer>();
    }

    void Update()
    {
        gridSize = waypointer.GetGridSize();
        SnapToGrid();
        waypointer.DisplayCoordTextMesh();
    }

    private void SnapToGrid()
    {
        //int gridSize = waypointer.GetGridSize();
        Vector2 gridSnap = waypointer.GetGridPosition();
        //gridSnap.y is actually the z plane
        transform.position = new Vector3(gridSnap.x * gridSize, 0f, gridSnap.y * gridSize);
    }

}
