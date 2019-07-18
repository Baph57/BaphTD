using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class EditorSnap : MonoBehaviour
{
    void Update()
    {
        Vector3 snapPosition;
        //
        snapPosition.x = Mathf.RoundToInt(transform.position.x / 10f) * 10f;
        snapPosition.z = 0f;

        transform.position = new Vector3(snapPosition.x, 0f, snapPosition.z);
    }
}
