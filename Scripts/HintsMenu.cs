using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.SceneManagement;

public class HintsMenu : MonoBehaviour
{
    public static bool HelpsCalled = false;
    public GameObject pauseMenuUI;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && SceneManager.GetActiveScene().buildIndex > 0)
        {
            if (HelpsCalled)
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
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        HelpsCalled = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        HelpsCalled = true;
    }
    public void Look()
    {
        CameraSwitch.LookAtMap = true;
    }
    public void Exit()
    {
        SceneManager.LoadScene(0);
    }
}
