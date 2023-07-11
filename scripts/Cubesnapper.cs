using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Cubesnapper : MonoBehaviour
{
    public float gridSize = 1f;
    public float z = 0f;
    public float snapThreshold = 0.2f; // Maximum distance for snapping to occur
    public GameObject gridVisualizationPrefab; // Prefab for the grid visualization

    private bool isDragging = false;
    private InputDevice targetDevice;
    private Vector3 initialPosition;
    private GameObject gridVisualization; // Reference to the grid visualization objectq

    private void Start()
    {
        if (XRSettings.enabled)
        {
            List<InputDevice> devices = new List<InputDevice>();
            InputDevices.GetDevices(devices);

            foreach (var device in devices)
            {
                if (device.characteristics.HasFlag(InputDeviceCharacteristics.HeldInHand))
                {
                    targetDevice = device;
                    break;
                }
            }
        }

        CreateGridVisualization();
    }

    private void Update()
    {
        if (XRSettings.enabled)
        {
            CheckInput();
        }
    }

    private void CheckInput()
    {
        targetDevice.TryGetFeatureValue(CommonUsages.triggerButton, out bool triggerButtonValue);
        targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue);

        if (triggerButtonValue && !isDragging)
        {
            // Start dragging
            isDragging = true;
            initialPosition = transform.position;
        }
        else if (!triggerButtonValue && isDragging)
        {
            // Stop dragging and snap to grid if close enough
            isDragging = false;
            if (Vector3.Distance(transform.position, GetNearestGridPosition()) <= snapThreshold)
            {
                SnapToGrid();
            }
        }
    }

    private void SnapToGrid()
    {
        Vector3 position = GetNearestGridPosition();
        position.z = z; // set the z to z when z is called z is used instead of pos.z
        transform.position = position;
    }

    private Vector3 GetNearestGridPosition()
    {
        Vector3 position = initialPosition;
        position.x = Mathf.Round(position.x / gridSize) * gridSize;
        position.y = Mathf.Round(position.y / gridSize) * gridSize;
        return position;
    }

    private void CreateGridVisualization()
    {
        if (gridVisualizationPrefab != null)
        {
            gridVisualization = Instantiate(gridVisualizationPrefab, Vector3.zero, Quaternion.identity);
            UpdateGridVisualization();
        }
    }

    private void UpdateGridVisualization()
    {
        if (gridVisualization != null)
        {
            Vector3 scale = new Vector3(gridSize, gridSize, 1f);
            gridVisualization.transform.localScale = scale;
        }
    }

    private void OnDestroy()
    {
        if (gridVisualization != null)
        {
            Destroy(gridVisualization);
        }
    }
}
