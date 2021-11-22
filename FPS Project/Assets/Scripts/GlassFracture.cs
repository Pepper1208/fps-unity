using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassFracture : MonoBehaviour
{
    public Camera fpscam;
    public string shootingobject;
    public GameObject fractured;
    public float breakForce;
    public AudioSource breakSound;
    // Update is called once per frame
    void Update()
    {
        
        Ray ray = new Ray(fpscam.transform.position, fpscam.transform.forward);
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit, 100f))
        {
            
            if (Input.GetMouseButton(0) && AmmoCounter.reloading == false)
            {
                shootingobject = hit.collider.name;
                if (hit.collider.name == "Glass")
                {
                    Fracture();
                }
            }

        }
        
    }
    void Fracture()
    {
        breakSound.Play();
        GameObject frac = Instantiate(fractured, transform.position, transform.rotation);

        foreach (Rigidbody rb in frac.GetComponentsInChildren<Rigidbody>())
        {
            Vector3 force = (rb.transform.position - transform.position).normalized * breakForce;
            rb.AddForce(force);
        }
        Destroy(gameObject);
        Destroy(frac, 3f);
    }
}
