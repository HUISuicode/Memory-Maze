using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class LookAtMap : MonoBehaviour
{
    public float scale;
    public GameObject button;
    private void Update()
    {
    }
    public void Look()
    {
        CameraSwitch.LookAtMap = true;
        Time.timeScale = 0f;
        Thread.Sleep(2000);
        Time.timeScale = 1f;
        CameraSwitch.LookAtMap = true;
    }
}
