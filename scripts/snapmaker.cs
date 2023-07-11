using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 - hey! can you make a c# script where it spawns game objects in a grid and you can increese saaid grid to make more of the objects, like how music has note sizes, 1/8, 1/4 ect


- Certainly! Here's a C# script that allows you to spawn game objects in a grid and increase the grid size dynamically:



using System.Collections.Generic;
using UnityEngine;

public class GridSpawner : MonoBehaviour
{
    public GameObject gridObjectPrefab;  // The prefab of the game object to spawn
    public int gridSize = 4;             // The initial size of the grid
    public float gridSpacing = 1f;       // The spacing between grid objects

    private List<GameObject> spawnedObjects = new List<GameObject>(); // List to keep track of spawned objects

    void Start()
    {
        SpawnGridObjects();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gridSize++; // Increase the grid size when the space key is pressed
            SpawnGridObjects();
        }
    }

    void SpawnGridObjects()
    {
        // Destroy any existing spawned objects
        foreach (GameObject obj in spawnedObjects)
        {
            Destroy(obj);
        }
        spawnedObjects.Clear();

        // Calculate the number of rows and columns in the grid
        int rows = Mathf.FloorToInt(Mathf.Sqrt(gridSize));
        int cols = Mathf.CeilToInt((float)gridSize / rows);

        // Calculate the center position of the grid
        Vector3 centerPosition = transform.position;

        // Calculate the starting position for the first grid object
        Vector3 spawnPosition = centerPosition - new Vector3(cols / 2f, 0f, rows / 2f) * gridSpacing;

        // Spawn grid objects in the grid
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                // Instantiate the grid object at the spawn position
                GameObject obj = Instantiate(gridObjectPrefab, spawnPosition, Quaternion.identity);
                spawnedObjects.Add(obj);

                // Move the spawn position to the next column
                spawnPosition.x += gridSpacing;
            }

            // Move the spawn position to the next row
            spawnPosition.x = centerPosition.x - (cols / 2f) * gridSpacing;
            spawnPosition.z += gridSpacing;
        }
    }
}
*/

public class snapmaker : MonoBehaviour
{
    public GameObject snapzone;
    public float notegridx;
    public float notegridy;
    private Vector3 notegridSubdivision;
    public float notegap;
    public GameObject bar;
    private GameObject spawnedBar;
    public Transform Plane;
    private float noteGridXBefore;
    private float noteGridYBefore;
    public List<GameObject> spawnedObjects;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Plane = GetComponent<Transform>();

        if (noteGridXBefore != notegridx || noteGridYBefore != notegridy) {
            UpdateSnap();
        }

        noteGridXBefore = notegridx;
        noteGridYBefore = notegridy; // it isnt. "(noteGridXBefore > notegridx)" and for the less sign
        // i think ^^^^ thats the problem as your assigning the old varible to the new one when before it gets changed
    }

    void UpdateSnap() {
        for (int i = 0; i < spawnedObjects.Count; i++) {
            Destroy(spawnedObjects[i].gameObject);
        } // will it work? idk
        spawnedObjects.Clear();
            for (int x = 0; x < notegridx; x++) {
                for (int y = 0; y < notegridy; y++) {
                    spawnedBar = Instantiate(snapzone, new Vector3(x, y) + Plane.position + Plane.forward * 1.5f, Quaternion.identity);
                    spawnedBar.name = "Cube" + x.ToString() + "-" + y.ToString();
                    spawnedBar.transform.SetParent(Plane);
                    spawnedObjects.Add(spawnedBar);
                }
            } 
    }
}


