using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChangeCaller : MonoBehaviour
{
    public CameraMotion camera;

    public delegate void JustCall();

    public event JustCall moved;

    void Start()
    {
        camera = FindObjectOfType<CameraMotion>();

        if(camera != null)
        {
            moved += camera.RefreshCameraPosition;
        }
    }
    void Update()
    {
        transform.position += new Vector3(0.01f,0,0);

        if(moved != null && transform.hasChanged)
        {
            moved();
        }
    }
}
