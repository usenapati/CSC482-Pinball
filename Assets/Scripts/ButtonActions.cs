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
        Application.Quit();
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
