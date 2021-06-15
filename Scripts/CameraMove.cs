using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Camera-Control/MouseLook")]
public class CameraMove : MonoBehaviour
{
    public enum RotationAxes { MouseXandY = 0, MouseX = 1, MouseY = 2};
    public RotationAxes axes = RotationAxes.MouseXandY;
    public static float sensetivityX = 2F; //sens
    public float sensetivityY = 2F;
    public float minX = -360f; // ограничения на поворот головы
    public float maxX = 360f;
    public float minY = 0;
    public float maxY = 180;
    float rotationX = 0f; // текущее значение бошки
    float rotationY = 0f;
    Quaternion originalRotation;
    void Start()
    {
        if (GetComponent<Rigidbody>())
        {
            GetComponent<Rigidbody>().freezeRotation = true;
        }
        originalRotation = transform.localRotation;
    }
    public static float Angle(float angle, float min, float max)
    {
        if (angle < -360f) angle += 360f;
        if (angle > 360f) angle -= 360f;
        return Mathf.Clamp(angle, min, max);
    }

    // Update is called once per frame
    void Update()
    {
        if (!HintsMenu.HelpsCalled && !Exit.ExitCalled)
        {
            if (axes == RotationAxes.MouseXandY)
            {
                rotationX += Input.GetAxis("Mouse X") * sensetivityX;
                rotationY += Input.GetAxis("Mouse Y") * sensetivityY;

                rotationX = Angle(rotationX, minX, maxX);
                rotationY = Angle(rotationY, minY, maxY);
                Quaternion xQuaternion = Quaternion.AngleAxis(rotationX, Vector3.up);
                Quaternion yQuaternion = Quaternion.AngleAxis(rotationY, -Vector3.right);
                transform.localRotation = originalRotation * xQuaternion * yQuaternion;
            }
            else if (axes == RotationAxes.MouseX)
            {
                rotationX += Input.GetAxis("Mouse X") * sensetivityX;
                rotationX = Angle(rotationX, minX, maxX);
                Quaternion xQuaternion = Quaternion.AngleAxis(rotationX, Vector3.up);
                transform.localRotation = originalRotation * xQuaternion;
            }
            else if (axes == RotationAxes.MouseY)
            {
                rotationY += Input.GetAxis("Mouse Y") * sensetivityY;
                rotationY = Angle(rotationY, minY, maxY);
                Quaternion yQuaternion = Quaternion.AngleAxis(rotationY, -Vector3.right);
                transform.localRotation = originalRotation * yQuaternion;
            }
        }
    }
}
