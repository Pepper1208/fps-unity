using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject pausemenu;

    // Update is called once per frame
    void Update()
    {
        // Detecting the appearance of the pause menu
        if (FPSController.pressedESC == 1)
        {
            pausemenu.SetActive(true);
            Time.timeScale = 0;
        } else if (FPSController.pressedESC == 0)
        {
            pausemenu.SetActive(false);
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
        } else
        {
            Debug.Log("Errors is occured in pause menu activating");
        }

        // Not usable
         //if (pausemenu.active == false)
         //{
         //    Cursor.lockState = CursorLockMode.Locked;
         //}
    }

    public void ReturnToStart()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
