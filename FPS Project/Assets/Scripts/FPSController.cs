using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    private CharacterController cc;
    public float moveSpeedv;
    public float moveSpeedh;
    public float jumpSpeed;

    private float horizontalMove, verticalMove;

    private Vector3 dir;

    public float gravity;

    private Vector3 velocity;


    public Transform groundCheck;

    public float checkRadius;

    public LayerMask groundLayer;

    static public bool isGround;
    public string lookingobject;

    static public int pressedESC = 0;

    private void Start()
    {
        cc = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        pressedESC = 0;
    }

    private void Update()
    {
        
        if(Gun.aiming == true)
        {
            moveSpeedv = 3;
            moveSpeedh = 3;
                PlayerStatusChange.Issprinting = false;

        }
        else if (PlayerStatusChange.Issprinting == true)
        {
            moveSpeedv = 8;
            moveSpeedh = 4;
        }
        else if(PlayerStatusChange.Iscrouching == true)
        {
            moveSpeedv = 3;
            moveSpeedh = 3;
        }
        else
        {
            moveSpeedv = 5;
            moveSpeedh = 4;
        }
        
        // Detecting ESC pressing amount

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Add 1 to pressedESC
            pressedESC++;

            // Detect the variable
            if (pressedESC % 2 == 1)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.lockState = CursorLockMode.Confined;
                // Debug.Log(pressedESC);
            } else if (pressedESC % 2 == 0)
            {
                Cursor.lockState = CursorLockMode.Confined;
                pressedESC = 0;
                // Debug.Log(pressedESC);
            } else {
                Debug.Log("The ESC detection caused error.");
            }

            
            
        }

        isGround = Physics.CheckSphere(groundCheck.position, checkRadius, groundLayer);

        if (isGround && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        horizontalMove = Input.GetAxis("Horizontal") * moveSpeedh;
        verticalMove = Input.GetAxis("Vertical") * moveSpeedv;

        dir = transform.forward * verticalMove + transform.right * horizontalMove;
        cc.Move(dir * Time.deltaTime);

        velocity.y -= gravity * Time.deltaTime;
        cc.Move(velocity * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGround)
        {
            
            velocity.y = jumpSpeed;

        }

        lookingobject = CameraRay.collidername;
    }
}

