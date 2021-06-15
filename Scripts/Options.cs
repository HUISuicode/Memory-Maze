using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Options : MonoBehaviour
    
{
    private static float currentVolume = 5;
    private double zxc;
    public Slider mainSlider;
    public Slider secslider;
    public Text txt;
    public Text txtSens;
    public Canvas mainCan;
    public GameObject AreYouSure;
    public void ChangeVolume()
    {
        mainCan.GetComponent<AudioSource>().volume = mainSlider.value;
        currentVolume = mainSlider.value;
        txt.GetComponent<Text>().text = (Mathf.Round((float)currentVolume)).ToString();
        PlayerPrefs.SetFloat("Sound", currentVolume);
    }
    public void ChangeSens()
    {
        CameraMove.sensetivityX = secslider.value;
        zxc = (double)CameraMove.sensetivityX;
        txtSens.GetComponent<Text>().text = (Mathf.Round((float)CameraMove.sensetivityX)).ToString();
    }
    public void Sure()
    {
        AreYouSure.SetActive(true);
    }
    public void ResetAllGame()
    {
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }
    public void OnOffMusic()
    {
        AudioListener.pause = !AudioListener.pause;
        if (AudioListener.pause == true)
            mainSlider.interactable = false;
        else mainSlider.interactable = true;
    }
}
