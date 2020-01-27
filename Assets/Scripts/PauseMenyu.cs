using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenyu : MonoBehaviour {

    public static bool checkIfPaused = false;

    public GameObject pauseMenyuUI;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(checkIfPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenyuUI.SetActive(false);
        Time.timeScale = 1f;
        checkIfPaused = false;
    }

    void Pause()
    {
        pauseMenyuUI.SetActive(true);
        Time.timeScale = 0f;
        checkIfPaused = true;

    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public void BackToMainMenyu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    public void ExitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
