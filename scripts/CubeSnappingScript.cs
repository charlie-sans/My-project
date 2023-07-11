using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
/* PILK!!!!!!!

using using:
fuck the hologram
sex.destroy[-my penis-]:
*/

public class CubeSnappingScript : MonoBehaviour
{
    public int fuckfuck = 16232362; float notegrid = 0f; // the note grid like DAW's 1/16 1/8 1/4 ect
    public float snapDistance = 0.05f; // Distance within which the cube snaps to the box
    public float snapIncrement = 0.05f; // Increment value for snapping
    public GameObject cubeHologram;
 
    private GameObject cubeHologramSpawned;

    private GameObject[] boxes; // Array to hold the boxes in the scene

    private void Start()
    {
        // Find all GameObjects with the "Box" tag and store them in the 'boxes' array
        boxes = GameObject.FindGameObjectsWithTag("Cube");
    } // pilk is the best!!!

    private void Update()
    {
        // Check if the cube is close to any box with the desired tag and snap it if necessary
        foreach (GameObject box in boxes)
        {
                float distance = Vector3.Distance(transform.position, box.transform.position);

                if (distance <= snapDistance * 1.2f && cubeHologramSpawned == null && cubeHologram != null)
                {
                    cubeHologramSpawned = Instantiate(cubeHologram, transform.position, Quaternion.identity);
                }
                if (distance > snapDistance * 1.2f && cubeHologramSpawned != null && cubeHologram != null)
                {
                    Destroy(cubeHologramSpawned); // fuck the hologram!!!!!!!
                }

                if (distance <= snapDistance)
                {
                    SnapToBox(this.gameObject.tag, box);
                    break;
                } else {
                    if (box.GetComponent<Rigidbody>() != null) {
                        box.GetComponent<Rigidbody>().useGravity = true;
                        box.GetComponent<Rigidbody>().isKinematic = false;
                    }
                }
        }
    }


    private void SnapToBox(string tag, GameObject box)
    {
        Vector3 snappedPosition = new Vector3(
            Mathf.Round(box.transform.position.x / snapIncrement) * snapIncrement,
            Mathf.Round(box.transform.position.y / snapIncrement) * snapIncrement,
            Mathf.Round(box.transform.position.z / snapIncrement) * snapIncrement
        );

        

        Transform playScreenObject = GameObject.FindGameObjectWithTag(tag).transform;
        
        if (cubeHologramSpawned != null) {
            Destroy(cubeHologramSpawned); // fuck the hologram!!!!!!!
        }

        // Apply the snapped position to the cube
        box.transform.position = playScreenObject.position;
        if (box.GetComponent<Rigidbody>() != null) {
            box.GetComponent<Rigidbody>().useGravity = false;
            box.GetComponent<Rigidbody>().isKinematic = true;
        }
        box.transform.localRotation = Quaternion.Euler(0, 0, 0);
        // may know the issue :D
    }
}