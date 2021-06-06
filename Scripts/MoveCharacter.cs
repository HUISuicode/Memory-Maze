using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.SceneManagement;

public class MoveCharacter : MonoBehaviour
{
    public int temp = 0;
    public float speed = 4.0f;
    private Vector3 moveDir = Vector3.zero;
    private CharacterController controller;
    public static bool[] loadLevel = new bool[8] { true, false, false, false, false, false, false, true };
    void Start()
    {
        controller = GetComponent<CharacterController>();
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
        if (this.CompareTag("Player") && other.CompareTag("Finish"))
        {
            loadLevel[SceneManager.GetActiveScene().buildIndex] = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            //CameraSwitch.flag = true;
            CameraSwitch.temp_flag = true;
            Thread.Sleep(1000);
            CameraSwitch.Fix();
        }
    }
}
