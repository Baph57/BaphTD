﻿using System.Collections;
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

    [SerializeField]
    public TowerRingBuffer towerRingBuffer;


    Vector2Int gridPosition;
    const int gridSize = 10;

    MeshRenderer[] testerHelp;
    MeshRenderer blueBlock;
    MeshRenderer redBlock;



    private void Start()
    {
        testerHelp = GetComponentsInChildren<MeshRenderer>();
        blueBlock = testerHelp[0];
        redBlock = testerHelp[1];

    }

    void Update()
    {
        ColorizeBlocks();
    }

    public MeshRenderer ColorizeBlocks(MeshRenderer blu, MeshRenderer red)
    {
        if (isPlayerInteractive)
        {
            red = Destroy.red;
            print(testerHelp[0]);
            print(testerHelp[1]);
            //testerHelp[0].GetComponentInChildren<MeshRenderer>().isVisible(false);

        }
    }

    public int GetGridSize()
    {
        return gridSize;
    }


    public Vector2Int GetGridPosition()
    {
        gridPosition.x = Mathf.RoundToInt(transform.position.x / gridSize);
        gridPosition.y = Mathf.RoundToInt(transform.position.z / gridSize);
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
        print(isPlayerInteractive);
        MeshRenderer topBlockMeshRenderer = transform.Find("Y+Plane").GetComponent<MeshRenderer>();
        topBlockMeshRenderer.material.color = color;
    }

    void OnMouseOver()
    {
        if (CrossPlatformInputManager.GetButton("Fire1"))
        {
            if (isPlayerInteractive)
            {
                //implementation of ring buffer for max tower placement
                towerRingBuffer.PlaceTower(this);
                print("Transform: " + gameObject.transform);
            }
            else
            {
                print("Invalid Placement for Turret");
            }
        }
        
    }
    void OnMouseExit()
    {
        //unsure if I want to do anything with this, but keeping for reference
    }
}
