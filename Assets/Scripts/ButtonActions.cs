using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonActions : MonoBehaviour
{

    public GameObject creditsPanel;

    public GameObject startPanel;

    public void Play() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Menu() 
    {
        SceneManager.LoadScene(0);
    }

    public void Quit() 
    {
        Debug.Log("Exit Button clicked");
#if UNITY_EDITOR
        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }

    public void OpenCredits() 
    {
        creditsPanel.SetActive(true);
        startPanel.SetActive(false);
    }

    public void CloseCredits() 
    {
        startPanel.SetActive(true);
        creditsPanel.SetActive(false);
    }
}
