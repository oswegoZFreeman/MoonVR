using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    private const float Y_ANGLE_MIN = 0.0f;
    private const float Y_ANGLE_MAX = 80.0f;

    public Transform lookAt;
    public Transform camTransform;
    public float distance = 5.0f;

    private float currentX = 0.0f;
    private float currentY = 45.0f;
    private float sensitivityX = 5.0f;
    private float sensitivityY = 5.0f;

    private void Start()
    {
        camTransform = transform;
    }

    private void Update()
    {
		//Cursor.lockState = CursorLockMode.Locked;
		//Cursor.visible = false;
        currentX += Input.GetAxis("Mouse X") * sensitivityX;
        currentY += Input.GetAxis("Mouse Y") * sensitivityY;

        currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
		//camTransform.transform.Rotate(-currentX, -currentY, 0);
		if(Input.GetKey("g"))
		{
			distance = 325f;
		}
		
		if(Input.GetKey("h"))
		{
			distance = 15f;
		}
		
    }

    private void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        camTransform.position = lookAt.position + rotation * dir;
        camTransform.LookAt(lookAt.position);
    }
}
