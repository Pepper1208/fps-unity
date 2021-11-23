using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Gun: MonoBehaviour
{
    public Transform gun;
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 10f;
    public GameObject theBullet;
    public Transform theMuzzle;
    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    static public bool aiming = false;
    public Transform origin;    
    private float nextTimeToFire = 0f;
    public AudioSource shootSound;
    
    
    
    static public bool isReloading = false;
    public Transform target;
    public float speed;

    static public float reloadTime = 2f;
    
    static public float currentAmmo;
    
    static public float maxAmmo = 40f;
    
    //public Vector3 originrotation = new Vector3(0, 10, 0);
    void Start()
    {
        isReloading = false;
        currentAmmo = maxAmmo;
    }
    void Update()
    {
        
        if (Input.GetMouseButton(1))
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            Aim();
            aiming = true;
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0, 10, 0);
            NotAim();
            aiming = false;
        }

        if (isReloading)
        {
            return;
        }

        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            
            
            return;
        }
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            if(AmmoCounter.reloading == false)
            {
                nextTimeToFire = Time.time + 1f / fireRate;

                Shoot();
            }
            
            
            


        }
    }
        

    IEnumerator Reload()
    {

        isReloading = true;
        yield return new WaitForSeconds(reloadTime);

        currentAmmo = maxAmmo;
        isReloading = false;
    }
    public void NotAim()
    {
        
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, origin.position, step);
    }
    public void Aim()
    {
        
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }
    public void Shoot()
    {
        currentAmmo--;
        muzzleFlash.Play();
        shootSound.Play();
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

        //GameObject bulletClone = Instantiate(theBullet, theMuzzle.position, theMuzzle.rotation);
       
        //Destroy(bulletClone, 4f);
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Target target = hit.transform.GetComponent<Target>();
            if(target != null)
            {
                target.TakeDamage(damage);
            }

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 1f);
            
        }
        
        
    }
}
