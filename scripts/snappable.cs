using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snappable : MonoBehaviour
{
    public string tagObject;
    private snapping SnapComponent;
    public Rigidbody rb;
    bool isSnapped;
    Vector3 snapPosition;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    bool CanSnap(Collision col)
    {
        return col.gameObject.CompareTag(tagObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (SnapComponent != null) {
            SnapComponent.Snapped = isSnapped;
        }

        if (rb != null)
        {
            rb.useGravity = !isSnapped;
            rb.isKinematic = isSnapped;
        }

        if (isSnapped)
        {
            transform.position = snapPosition;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<snapping>() == null)
        {
            Debug.Log("NO SNAP COMPONENT!!!1");
        }
        else
        {
            SnapComponent = other.gameObject.GetComponent<snapping>();
        }
        if (CanSnap(other) && rb != null)
        {
            if (SnapComponent != null && SnapComponent.CanSnap)
            {
                Debug.Log("can snap!");
                snapPosition = other.transform.position;
                isSnapped = true;
            }

            Debug.Log("helo :D");
        }
    }

    private void OnCollisionExit(Collision other)
    {
        // isSnapped = false;
        if (CanSnap(other) && SnapComponent != null && other.gameObject == SnapComponent.gameObject)
        {
            SnapComponent = null;
            isSnapped = false;
        }
    }
}