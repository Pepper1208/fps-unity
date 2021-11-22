using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //private float speed = 15.0f;
    public bool hitted;
    public Camera fpsCam;
    public Transform theMuzzle;

    private Vector3 velocity;
    public Transform groundCheck;

    public float checkRadius;

    public LayerMask groundLayer;

    

        // Start is called before the first frame update
    void Start()
    {
        Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;

        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
        {


            targetPoint = hit.point;
        }
        else
        {


            targetPoint = ray.GetPoint(1000);
        }
        velocity = (targetPoint - theMuzzle.position).normalized * 10;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += velocity * Time.deltaTime;
        
        hitted = Physics.CheckSphere(groundCheck.position, checkRadius, groundLayer);
        if (hitted)
        {
            Destroy(gameObject);
        }
    }

}
