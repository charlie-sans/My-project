using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Presets;
using UnityEngine;
using UnityEngine.XR;

public class showcubetrigger : MonoBehaviour
{
    private InputDevice device;
    private bool isDeviceInitialized = false;
    private bool isCubeGrabbed = false;
    private GameObject grabbedCube;

    public Transform pointingDevice;

    void Start()
    {
        InitializeController();
    }
    void InitializeController()
    {
        if (!isDeviceInitialized)
        {
            // Get the device associated with the left hand controller
            InputDevices.deviceConnected += OnDeviceConnected;
            TryGetDeviceByRole(InputDeviceRole.LeftHanded, out device);
        }
    }

    void OnDeviceConnected(InputDevice device)
    {
        if (!isDeviceInitialized && device.isValid && device.characteristics.HasFlag(InputDeviceCharacteristics.Controller))
        {
            InitializeController();
        }
    }

    bool TryGetDeviceByRole(InputDeviceRole role, out InputDevice device)
    {
        var inputDevices = new List<InputDevice>();
        InputDevices.GetDevicesWithRole(role, inputDevices);

        if (inputDevices.Count > 0)
        {
            device = inputDevices[0];
            isDeviceInitialized = true;
            return true;
        }

        device = default(InputDevice);
        return false;
    }

    void Update()
    {
        if (isDeviceInitialized && device != null)
        {
            // Check for specific input buttons
            if (device.TryGetFeatureValue(CommonUsages.triggerButton, out bool triggerButtonPressed))
            {
                if (triggerButtonPressed)
                {
                    if (!isCubeGrabbed)
                    {
                        GrabCube();
                    }
                }
                else
                {
                    if (isCubeGrabbed)
                    {
                        ReleaseCube();
                    }
                }
            }
        }
    }

    void GrabCube()
    {
        // Raycast from pointing device to find cube to grab
        if (Physics.Raycast(pointingDevice.position, pointingDevice.forward, out RaycastHit hit, Mathf.Infinity))
        {
            if (hit.collider.CompareTag("Cube"))
            {
                grabbedCube = hit.collider.gameObject;
                grabbedCube.transform.SetParent(pointingDevice);
                grabbedCube.transform.localPosition = Vector3.zero;
                grabbedCube.GetComponent<Rigidbody>().isKinematic = true;
                isCubeGrabbed = true;
            }
        }
    }

    void ReleaseCube()
    {
        if (grabbedCube != null)
        {
            grabbedCube.transform.SetParent(null);
            grabbedCube.GetComponent<Rigidbody>().isKinematic = false;
            grabbedCube = null;
            isCubeGrabbed = false;
        }
    }
}