using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamZoom : MonoBehaviour
{
    public int zoom = 20;
    int normal = 60;
    float smooth = 5;
    public int sprintzoom = 100;
    private bool isZoomed = false;

    void Update()
    {
        if (isZoomed)
        {
            GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, zoom, Time.deltaTime * smooth);
        }
        else if (PlayerStatusChange.Issprinting == true)
        {
            GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, sprintzoom, Time.deltaTime * smooth);
        }
        else
        {
            GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, normal, Time.deltaTime * smooth);
        }
        
        if (Input.GetMouseButton(1))
        {
            isZoomed = true;
        }
        else
        {
            isZoomed = false;
        }

        
    }

}
