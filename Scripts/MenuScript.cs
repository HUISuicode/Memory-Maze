using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Threading;

public class MenuScript : MonoBehaviour
{
    public GameObject zxc1;
    public GameObject zxc2;
    public GameObject zxc3;
    public GameObject zxc4;
    public GameObject zxc5;
    public GameObject zxc6;
    public void Scenes(int index)
    {
        CameraSwitch.Restart = true;
        Exit.ExitCalled = false;
        HintsMenu.HelpsCalled = false;
        Cursor.visible = true;
        SceneManager.LoadScene(index);
    }
    public void Exit1()
    {
        Application.Quit();
    }
    //public void ChangeImage(int indexl)
    //{
    //    if (true)
    //    {
    //        var zxc = GameObject.Find("Lvl1");
    //        zxc.GetComponent<Image>().color = new Vector4(79 / 255.0f, 165 / 255.0f, 63 / 255.0f, 1);
    //    }
    //}
    private void Update()
    {
        
        if (SceneManager.GetActiveScene().buildIndex == 0)
            Cursor.visible = true;
        if (MoveCharacter.loadLevel[1] || PlayerPrefs.HasKey("CompleteLevel" + 1))
        {
            zxc1.GetComponent<Image>().color = new Vector4(255f, 255f, 255f, 1);
        }
        if (MoveCharacter.loadLevel[2] || PlayerPrefs.HasKey("CompleteLevel" + 2))
        {
            zxc2.GetComponent<Image>().color = new Vector4(255f, 255f, 255f, 1);
        }
        if (MoveCharacter.loadLevel[3] || PlayerPrefs.HasKey("CompleteLevel" + 3))
        {
            zxc3.GetComponent<Image>().color = new Vector4(255f, 255f, 255f, 1);
        }
        if (MoveCharacter.loadLevel[4] || PlayerPrefs.HasKey("CompleteLevel" + 4))
        {
            zxc4.GetComponent<Image>().color = new Vector4(255f, 255f, 255f, 1);
        }
        if (MoveCharacter.loadLevel[5] || PlayerPrefs.HasKey("CompleteLevel" + 5))
        {
            zxc5.GetComponent<Image>().color = new Vector4(255f, 255f, 255f, 1);
        }
        if (MoveCharacter.loadLevel[6] || PlayerPrefs.HasKey("CompleteLevel" + 6))
        {
            zxc6.GetComponent<Image>().color = new Vector4(255f, 255f, 255f, 1);
        }
    }
}
