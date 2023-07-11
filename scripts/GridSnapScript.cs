using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSnapScript : MonoBehaviour
{
    public string targetTag = "UrTag";
    public float gridSize = 1f;

    private void Update()
    {
        GameObject[] objectsToSnap = GameObject.FindGameObjectsWithTag(targetTag);

        foreach (GameObject obj in objectsToSnap)
        {
            SnapToGrid(obj.transform);
        }
    }

    private void SnapToGrid(Transform objectTransform)
    {
        Vector3 newPosition = new Vector3(
            Mathf.Round(objectTransform.position.x / gridSize) * gridSize,
            Mathf.Round(objectTransform.position.y / gridSize) * gridSize,
            Mathf.Round(objectTransform.position.z / gridSize) * gridSize
        );

        objectTransform.position = newPosition;
    }
}