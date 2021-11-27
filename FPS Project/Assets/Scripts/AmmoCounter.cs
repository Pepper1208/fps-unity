using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class AmmoCounter : MonoBehaviour
{
    public Text ammoDisplay;
    public Slider ammoSlider;
    
    static public bool reloading = false;
    public bool stopReload;


    public float reload_time = 2.0f;
    public float timer = 0.0f;
    public float ammo_num = 0.0f;
    public float ammo_update = 0.0f;
    public float ammo_max_num;
    public double ammo_int = 0;
    public float originalAmmo;
    void Start()
    {
        if (WeaponSwitching.selectedWeapon == 0)
        {
            ammo_max_num = 40;
        }
        if (WeaponSwitching.selectedWeapon == 1)
        {
            ammo_max_num = 20;
        }
        reload_time = 2.0f;
        
        ammoDisplay.text = Gun.maxAmmo.ToString();
        stopReload = false;
        ammoSlider.maxValue = Gun.maxAmmo;
        ammoSlider.value = Gun.maxAmmo;
    }

    
    void Update()
    {
        
        // Start reloading script e.g. animation
        if (reloading)
        {
            if (stopReload == false)
            {
                
                timer += Time.deltaTime;
                

                ammo_int = Mathf.Floor(timer * (ammo_max_num/reload_time)) + originalAmmo;
                Gun.currentAmmo = (float)ammo_int;
                if (timer > reload_time)
                {
                    timer = timer - reload_time;
                    
                    stopReload = true;
                    // Successfully reloaded script
                }
                if(ammo_int >= ammo_max_num)
                {
                    stopReload = true;
                }
            }
            else
            {
                reloading = false;
                ammo_int = 0;
                timer = 0;
                stopReload = false;
            }
        }
        
        ammoDisplay.text = Gun.currentAmmo.ToString();
        ammoSlider.value = Gun.currentAmmo;
        
        
            

        if (Gun.currentAmmo <= 0 && reloading == false)
        {
            originalAmmo = Gun.currentAmmo;
            reloading = true;  
        }
        if (Input.GetButtonDown("Reload") && reloading == false)
        {
            originalAmmo = Gun.currentAmmo;
            reloading = true;

        }
        
        
    }

    
}
