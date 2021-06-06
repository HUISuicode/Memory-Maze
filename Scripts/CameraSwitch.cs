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
    public static bool camera = false; 
    public static bool flag = true;
    public static bool flag1 = true;
    public static bool temp_flag = false;
    public static bool eshe_flag = true;
    public static int levels = 1;
    public static bool LookAtMap = false;
    public static bool canvasDisable = false;
    private static int lastCalledScene = -1;
    public Canvas canvas;
    public static bool EndHint1 = false;
    void Start()
    {
        camMain = GetComponent<Camera>();
        camMain = Camera.main;
    }
    
    void Update()
    {
        //if (eshe_flag && SceneManager.GetActiveScene().buildIndex >= 2)
        //{
        //    eshe_flag = false;
        //    camMain.enabled = !camMain.enabled;
        //    cam.enabled = !cam.enabled;
        //    flag = true;
        //}
        
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
        if (SceneManager.GetActiveScene().buildIndex > levels && temp_flag)
        {
            flag = true;
            camera = false;
            flag1 = true;
            temp_flag = false;
        }
        if (LookAtMap)
        {
            camera = false;
            Hint1();
            EndHint1 = true;
        }
        if (Input.GetKeyDown(KeyCode.E) && EndHint1)
        {
            Hint1();
            camera = true;
            EndHint1 = false;
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
    public static void Fix()
    {
        temp_flag = true;
    }
}