using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CameraSwitch : MonoBehaviour
{
    public Camera camMain;
    public Camera cam;
    public Canvas text;
    public GameObject SimpleSimon;
    public GameObject FindAPair;
    public GameObject game;
    public Text win;
    public static bool camera, temp_flag, eshe_flag, LookAtMap, canvasDisable, Restart, EndHint1, Simon, saimonBool = false;
    public static bool flag = true;
    public static bool flag1 = true;
    public static bool flagForPairs = true;
    public static bool flagForPairs1 = true;
    public static bool findPair;
    public Canvas canvas;
    public static Button temporaryButton;
    public static int leftCards = 12;
    //public static Button
    void Start()
    {
        camMain = GetComponent<Camera>();
        camMain = Camera.main;
    }
    void Update()
    {
        if (PlayerPrefs.HasKey("Sound"))
            game.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("Sound");
        if (Restart)
        {
            flag = true;
            flag1 = true;
            EndHint1 = false;
            Restart = false;
        }
        if (flag)
        {
            flag = false;
            camMain.enabled = !camMain.enabled;
            cam.enabled = !cam.enabled;
        }
        if (Input.GetKeyDown(KeyCode.E) && flag1)
        {
            text.enabled = !text.enabled;
            camera = true;
            flag1 = false;
            camMain.enabled = !camMain.enabled;
            cam.enabled = !cam.enabled;
        }
        if (SceneManager.GetActiveScene().buildIndex > 1 && temp_flag)
        {
            flag = true;
            camera = false;
            flag1 = true;
            temp_flag = false;
        }
        if (LookAtMap)
        {
            camera = false;
            EndHint1 = true;
            Hint1();
        }
        if (Input.GetKeyDown(KeyCode.E) && EndHint1)
        {
            Hint1();
            camera = true;
            EndHint1 = false;
        }
        if (saimonBool)
        {
            camera = false;
            saimonBool = false;
            SimpleSimon.SetActive(true);
        }
        if (findPair)
        {
            camera = false;
            findPair = false;
            FindAPair.SetActive(true);
        }
    }
    void Hint1()
    {
        LookAtMap = false;
        text.enabled = !text.enabled;
        canvas.enabled = !canvas.enabled;
        camMain.enabled = !camMain.enabled;
        cam.enabled = !cam.enabled;
    }
    
}