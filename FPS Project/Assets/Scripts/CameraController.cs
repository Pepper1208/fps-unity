using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    static public float mouseX, mouseY;
    public float mouseSensitivity;
    static public float xRotation;
    public Camera playerCamera;
    public GameObject crouchPosition;
    public GameObject originalPosition;
    public float smooth = 0.5f;

    private void Update ()
    {
        mouseX = Input.GetAxis ("Mouse X") * mouseSensitivity * Time.deltaTime;
        mouseY = Input.GetAxis ("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp (xRotation, -70f, 70f);

        player.Rotate (Vector3.up * mouseX);
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        
        if(PlayerStatusChange.Iscrouching == true)
        {
            playerCamera.transform.position = Vector3.Lerp(playerCamera.transform.position, crouchPosition.transform.position, Time.deltaTime * smooth);
        }
        else
        {
            playerCamera.transform.position = Vector3.Lerp(playerCamera.transform.position, originalPosition.transform.position, Time.deltaTime * smooth);
        }
    }
}
