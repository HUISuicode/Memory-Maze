using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.SceneManagement;

public class MoveCharacter : MonoBehaviour
{
    public static float volume;
    public float speed = 4.0f;
    private Vector3 moveDir = Vector3.zero;
    private CharacterController controller;
    public static bool[] loadLevel = new bool[8] { true, false, false, false, false, false, false, true };
    void Start()
    {
        controller = GetComponent<CharacterController>();
        for (int i = 1; i < 7; i++)
        {
            if (PlayerPrefs.HasKey("CompleteLevel" + i))
                loadLevel[i] = true;
        }
    }

    // Update is called once per fram
    void FixedUpdate()
    {

        if (CameraSwitch.camera)
        {
            moveDir = new Vector3(Input.GetAxis("Vertical"), 0, Input.GetAxis("Horizontal") * (-1));
            moveDir = transform.TransformDirection(moveDir);
            moveDir *= speed;
            controller.Move(moveDir * Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (this.CompareTag("Player") && other.CompareTag("Finish") && SceneManager.GetActiveScene().buildIndex != 6)
        {
            PlayerPrefs.SetString("CompleteLevel" + SceneManager.GetActiveScene().buildIndex, "true");
            loadLevel[SceneManager.GetActiveScene().buildIndex] = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            CameraSwitch.temp_flag = true;
            Thread.Sleep(1000);
            HintsMenu.hintCount++;
            PlayerPrefs.SetInt("hintCount", HintsMenu.hintCount);
        }
    }
}
