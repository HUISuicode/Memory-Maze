using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Findapair : MonoBehaviour
    
{
    public int[,] pairs = new int[6, 4];
    public Button buttonX;
    public Button buttonY;
    public bool youCanClick = true;
    //public Image image;
    public Text win;
    public static bool Finder = true;
    public void Start()
    {
        Finder = true;
    }
    public void Clicked()
    {
        if (youCanClick)
        {
            CameraSwitch.flagForPairs1 = true;
            buttonX.GetComponent<Animation>().Play("Flip");
            buttonX.GetComponent<Animation>().Play("flip" + buttonX.name);
            if (CameraSwitch.flagForPairs)
            {
                CameraSwitch.flagForPairs = false;
                CameraSwitch.temporaryButton = buttonX;
                CameraSwitch.flagForPairs1 = false;
                CameraSwitch.temporaryButton.interactable = false;
            }
            if (CameraSwitch.temporaryButton.name == this.name && CameraSwitch.flagForPairs1)
            {
                youCanClick = false;
                Invoke("Ya_Ustal", 0.22f);
                CameraSwitch.flagForPairs1 = true;
                CameraSwitch.flagForPairs = true;
                CameraSwitch.leftCards--;
            }
            else if (CameraSwitch.temporaryButton.name != this.name)
            {
                youCanClick = false;
                Invoke("zxc", 0.4f);
                CameraSwitch.flagForPairs1 = true;
                CameraSwitch.flagForPairs = true;
            }
        }
        if (CameraSwitch.leftCards == 0)
        {
            win.enabled = true;
            HintsMenu.hintCount++;
            Finder = false;
            HintsMenu.currentHint++;
            PlayerPrefs.SetInt("hintCount", HintsMenu.hintCount);
            PlayerPrefs.SetInt("currentHint", HintsMenu.currentHint);
        }
    }
    public void Ya_Ustal()
    {
        buttonX.GetComponent<Animation>().Play("destroy");
        buttonY.GetComponent<Animation>().Play("destroy");
        Destroy(buttonX);
        Destroy(buttonY);
        youCanClick = true;
    }
    public void Exit()
    {
        CameraSwitch.camera = true;
        Finder = false;
        CameraSwitch.camera = true;
    }
    public void zxc()
    {
        buttonX.GetComponent<Animation>().Play("flipback");
        CameraSwitch.temporaryButton.GetComponent<Animation>().Play("flipback");
        CameraSwitch.temporaryButton.interactable = true;
        CameraSwitch.temporaryButton = default;
        youCanClick = true;
    }
    public void PlayAnimation()
    {
        buttonX.GetComponent<Animation>().Play("Flip");
    }
}
