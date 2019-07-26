using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Waypointer : MonoBehaviour
{


    //public data type is ok because it's a data class
    //we declare these as public because we expect their values to be changed elsewhere
    public bool blockHasBeenExplored = false;
    public bool isPlayerInteractive = true;
    public Waypointer previouslyAccessedWaypoint;
    //SerializeField may be better for tower to prevent
    //other classes from accessing this GameObject
    public GameObject placeableTower;


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

     void OnMouseOver()
    {
        if (CrossPlatformInputManager.GetButton("Fire1"))
        {
            if (isPlayerInteractive)
            {

                //Instantiate(placeableTower, gameObject.transform);
                var newTowerPosition = new Vector3(gameObject.transform.position.x, byte.MinValue, gameObject.transform.position.z);
                Instantiate(placeableTower, newTowerPosition, Quaternion.identity);
                isPlayerInteractive = false;
                print("Transform: " + gameObject.transform);
            }
            else
            {
                print("didnt gettem");
            }
        }
        
    }
    void OnMouseExit()
    {
        //unsure if I want to do anything with this, but keeping for reference
    }
}
