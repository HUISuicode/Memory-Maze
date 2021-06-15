using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HintsMenu : MonoBehaviour
{
    public static bool HelpsCalled = false;
    public Text number;
    public Text outOfHints;
    public Text nomorehints;
    public static int hintCount = 2;
    public GameObject pauseMenuUI;
    public static int currentHint = 1;
    private void Update()
    {
        number.GetComponent<Text>().text = hintCount.ToString();
        if (Input.GetKeyDown(KeyCode.Q)
            && SceneManager.GetActiveScene().buildIndex > 0
            && !Exit.ExitCalled
            && !CameraSwitch.flag1
            && !CameraSwitch.EndHint1)
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
        if (CameraSwitch.saimonBool) pauseMenuUI.SetActive(false);
        if (CameraSwitch.findPair) pauseMenuUI.SetActive(false);
        if (PlayerPrefs.HasKey("hintCount")) hintCount = PlayerPrefs.GetInt("hintCount");
        if (PlayerPrefs.HasKey("currentHint")) currentHint = PlayerPrefs.GetInt("currentHint");
        Debug.Log(currentHint);
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        HelpsCalled = false;
        outOfHints.enabled = false;
        nomorehints.enabled = false;
    }
    public void ResumeForHint()
    {
        if (currentHint != 3)
        {
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            HelpsCalled = false;
            outOfHints.enabled = false;
        }
        else nomorehints.enabled = true;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        HelpsCalled = true;
    }
    public void Look()
    {
        if (hintCount != 0)
        {
            hintCount--;
            PlayerPrefs.SetInt("hintCount", hintCount);
            CameraSwitch.LookAtMap = true;
        }
        else outOfHints.enabled = true;
    }
    public void GetHint()
    {
        if (currentHint == 1)
        {
            CameraSwitch.saimonBool = true;
        }
        else if (currentHint == 2)
            CameraSwitch.findPair = true;
        else
        {
            nomorehints.enabled = true;
            pauseMenuUI.SetActive(true);
            CameraSwitch.findPair = false;
            CameraSwitch.saimonBool = false;
        }
    }
}
