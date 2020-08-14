using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCon : MonoBehaviour
{
    [SerializeField]
    private GameObject Target;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float MinZoom;
    [SerializeField]
    private float MaxZoom;
    [SerializeField]
    private float Sensitivity;

    void Update()
    {
        if (Input.GetMouseButton(2))
        {
            transform.RotateAround(Target.transform.position, transform.up, Input.GetAxis("Mouse X") * speed);
            transform.RotateAround(Target.transform.position, transform.right, Input.GetAxis("Mouse Y") * -speed);
        }

        float fov = Camera.main.fieldOfView;
        fov += Input.GetAxis("Mouse ScrollWheel") * -Sensitivity;
        fov = Mathf.Clamp(fov, MinZoom, MaxZoom);
        Camera.main.fieldOfView = fov;
        transform.LookAt(Target.transform.position);
    }
}
