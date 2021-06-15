using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public static bool ExitCalled = false;
    public GameObject pauseMenuUI;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)
            && SceneManager.GetActiveScene().buildIndex > 0
            && !HintsMenu.HelpsCalled
            && !CameraSwitch.EndHint1)
        {
            if (ExitCalled)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        if (CameraSwitch.camera && !HintsMenu.HelpsCalled && SceneManager.GetActiveScene().buildIndex != 0 && !ExitCalled)
            Cursor.visible = false;
        else
            Cursor.visible = true;
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        ExitCalled = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        ExitCalled = true;
    }
    public void Exite()
    {
        Time.timeScale = 1f;
        ExitCalled = false;
        SceneManager.LoadScene(0);
    }
}
