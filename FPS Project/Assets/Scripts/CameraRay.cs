using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRay : MonoBehaviour
{
    static public string collidername;
    public float distance;
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            distance = hit.distance;

            if (distance < 8)
            {
                //Debug.Log(hit.collider.name);

                Debug.DrawLine(ray.origin, hit.point, Color.red);

                collidername = hit.collider.name;
            }
            else
            {
                //Debug.Log(" ");

                collidername = " ";
            }

            

            



        }
        




        

    }
}

