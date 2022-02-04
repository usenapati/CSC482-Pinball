using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseWatcher : MonoBehaviour
{
    
    public GameObject pausePanel;
    
    private bool paused = false;

    public void Pause(InputAction.CallbackContext context)
    {
        if (context.ReadValue<float>() > 0)
        {
            if (!paused) 
            {
                Time.timeScale = 0;
                pausePanel.SetActive(true);
                paused = true;
            }
            else
            {
                Time.timeScale = 1;
                pausePanel.SetActive(false);
                paused = false;
            }
        }
        
    }
}
