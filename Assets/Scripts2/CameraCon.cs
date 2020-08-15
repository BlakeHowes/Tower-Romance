using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCon : MonoBehaviour
{
    [SerializeField]
    private bool PanOrbitToggle;
    [SerializeField]
    private GameObject Target;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float OribtSpeed;
    [SerializeField]
    private float Scrollspeed;
    [SerializeField]
    private float MinZoom;
    [SerializeField]
    private float MaxZoom;
    [SerializeField]
    private float Sensitivity;
    private Vector3 Startpos;
    private Quaternion StartRot;
    private bool SwitchtoPan = false;

    private void Awake()
    {
        Startpos = transform.position;
        StartRot = transform.rotation;
    }

    void Update()
    {

        float fov = Camera.main.fieldOfView;
        fov += Input.GetAxis("Mouse ScrollWheel") * -Scrollspeed;
        fov = Mathf.Clamp(fov, MinZoom, MaxZoom);
        Camera.main.fieldOfView = fov;

        if (PanOrbitToggle == true)
        {
            if (Input.GetMouseButton(2))
            {
                transform.RotateAround(Target.transform.position, transform.up, Input.GetAxis("Mouse X") * OribtSpeed);
                transform.RotateAround(Target.transform.position, transform.right, Input.GetAxis("Mouse Y") * -OribtSpeed);
                transform.LookAt(Target.transform.position);
            }
            SwitchtoPan = true;
        }
        else
        {
            if(SwitchtoPan == true)
            {
                transform.position = Startpos;
                transform.rotation = StartRot;
                SwitchtoPan = false;
            }

            if (Input.GetMouseButton(2))
            {
                Sensitivity = speed * ((fov));
                Vector3 PosChange = new Vector3
                    (
                     Input.GetAxis("Mouse X") * Sensitivity * Time.deltaTime,
                     0f,
                     Input.GetAxis("Mouse Y") * Sensitivity * Time.deltaTime
                    );
                transform.position -= PosChange;
            }
        }
    }

    public void SwitchToPan()
    {
        PanOrbitToggle = false;
    }

    public void SwitchToOrbit()
    {
        PanOrbitToggle = true;
    }
}
