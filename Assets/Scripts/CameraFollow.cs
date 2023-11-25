using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Camera Follow
    [SerializeField] private Vector3 offset = new Vector3(0f,0f,-10f);
    [SerializeField] private float followSmoothTime = 0.25f;
    [SerializeField] private Vector3 followVelocity = Vector3.zero;

    [SerializeField] private Transform target;

    // Camera Zoom
    private float zoom;
    [SerializeField] private float zoomMultiplier = 4f;
    [SerializeField] private float minZoom = 2f;
    [SerializeField] private float maxZoom = 8f;
    [SerializeField] private float zoomVelocity = 0f;
    [SerializeField] private float zoomSmoothTime = 0.25f;

    [SerializeField] private Camera cam;

    private void Start()
    {
        zoom = cam.orthographicSize;
    }

    private void Update()
    {
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition,ref followVelocity, followSmoothTime );

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        zoom -= scroll * zoomMultiplier;
        zoom = Mathf.Clamp( zoom, minZoom, maxZoom );
        cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, zoom, ref zoomVelocity, zoomSmoothTime);
    }


}
