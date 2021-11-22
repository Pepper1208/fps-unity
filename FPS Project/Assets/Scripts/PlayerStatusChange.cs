using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatusChange : MonoBehaviour
{
    public Sprite stand;
    public Sprite sprint;
    public Sprite crouch;
    static public bool Issprinting = false;
    static public bool Iswalking = true;
    static public bool Iscrouching = false;
    // Start is called before the first frame update
    void Start()
    {
        Iswalking = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Sprint") && Input.GetButton("Vertical") && Issprinting == false && Gun.aiming == false && Iscrouching == false)
        {
            Issprinting = true;
            Iswalking = false;
            Iscrouching = false;
        }
        else if (Input.GetButton("Crouch") && FPSController.isGround == true)
        {
            Iscrouching = true;
            Issprinting = false;
            Iswalking = false;
        }
        else if (Input.GetButton("Crouch") && Input.GetButton("Vertical") && FPSController.isGround == true)
        {
            Iscrouching = true;
            Issprinting = false;
            Iswalking = false;
        }
        else if (Issprinting == true && Input.GetButton("Vertical"))
        {
            Iswalking = false;
            Issprinting = true;
            Iscrouching = false;
        }
        else
        {
            Iswalking = true;
            Issprinting = false;
            Iscrouching = false;
        }
        if (Issprinting)
        {
            gameObject.GetComponent<UnityEngine.UI.Image>().overrideSprite = sprint;
        }
        if (Iswalking)
        {
            gameObject.GetComponent<UnityEngine.UI.Image>().overrideSprite = stand;
        }
        if (Iscrouching)
        {
            gameObject.GetComponent<UnityEngine.UI.Image>().overrideSprite = crouch;
        }
            
    }
}
