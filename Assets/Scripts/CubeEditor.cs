using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
//SelectionBase means that whatever the script is attached to is the "default" item/prefab
//to grab when clicked on in the editor
[SelectionBase] 
public class CubeEditor : MonoBehaviour
{
    [Range(1f, 20f)][SerializeField] float gridSize = 10f;

    TextMesh coordinateTextMesh;

    void Update()
    {
        Vector3 snapPosition;
        snapPosition.x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize;
        snapPosition.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;
        transform.position = new Vector3(snapPosition.x, 0f, snapPosition.z);

        //label on top of box for coordinates
        coordinateTextMesh = GetComponentInChildren<TextMesh>();
        coordinateTextMesh.text = snapPosition.x + "," + snapPosition.z;
    }

}
