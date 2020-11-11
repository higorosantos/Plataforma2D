using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotion : MonoBehaviour
{
   
    public Transform player;

    public Vector3 aditionalPos;

    [Range(-50f, 50f)]public float cameraDistance;
    [Range(-1, 1)]public sbyte switcherDistance;

    public bool smoothLerp = true; 
    [Range(0, 1f)]public float lerpTime;

    public Ray cameraRay;


    void Start()
    {
        
    }

    void Update()
    {
       // RefreshCameraPosition();
    }

    public void RefreshCameraPosition()
    {
        if(player != null && player.tag == "Player")
        {
            UpdateRay();
            ApllyRayPoint(cameraRay.GetPoint(-cameraDistance) + aditionalPos);

            Debug.DrawLine(player.position, transform.position);
            Debug.DrawLine(player.position, cameraRay.GetPoint(cameraDistance) * switcherDistance);
        }
    }
    
    public void UpdateRay()
    {
        cameraRay = new Ray(player.position, player.forward);
    }

    public void ApllyRayPoint(Vector3 point)
    {
        if(smoothLerp)
        {
            transform.position = Vector3.Lerp(transform.position, point, lerpTime);
        }
        else
        {
            transform.position = point;
        }
    }

}
