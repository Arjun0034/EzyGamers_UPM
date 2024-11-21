using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public Canvas pauseCanvas;
    public void Play()
    {
        SceneManager.LoadScene(1);
        Debug.Log("Play Button Pressed");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        Debug.Log("MainMenu Button Pressed");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Game Quit");
    }

    public void Pause()
    {
        pauseCanvas.gameObject.SetActive(true);
    }

    public void Resume()
    {
        pauseCanvas.gameObject.SetActive(false);
    }
}
