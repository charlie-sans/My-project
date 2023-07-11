using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snapping : MonoBehaviour
{
    public bool CanSnap;
    public bool Snapped;
    public GameObject hologramSpawnPrefab;
    private GameObject hologramSpawned;

    // Start is called before the first frame update
    void Start()
    {
        if (hologramSpawnPrefab != null)
        {
            hologramSpawned = Instantiate(hologramSpawnPrefab, transform.position, Quaternion.identity);
            hologramSpawned.transform.SetParent(this.transform);
        }
    }

    private void Update()
    {
        hologramSpawned.SetActive(!Snapped);
    }
}