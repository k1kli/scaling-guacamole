using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform camera;
    public Transform cameraHorizontalRotator;
    public float cameraSpeedX = 300.0f;
    public float cameraSpeedY = 300.0f;
    public float playerSpeedForward = 2.0f;
    public float playerSpeedSideways = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CameraMovement();
        PlayerMovement();
    }
    void CameraMovement()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        if (Mathf.Abs(mouseX) > float.Epsilon)
        {
            cameraHorizontalRotator.Rotate(0.0f, mouseX * cameraSpeedX * Time.deltaTime, 0.0f);
        }
        if (Mathf.Abs(mouseY) > float.Epsilon)
        {
            camera.Rotate(-mouseY * cameraSpeedY * Time.deltaTime, 0.0f, 0.0f);
        }
    }
    void PlayerMovement()
    {
        float playerX = Input.GetAxis("Horizontal");
        float playerY = Input.GetAxis("Vertical");
        if (Mathf.Abs(playerX) > float.Epsilon)
        {
            Vector3 right = cameraHorizontalRotator.right;
            transform.localPosition = transform.localPosition + playerX * right * playerSpeedSideways * Time.deltaTime;
        }
        if (Mathf.Abs(playerY) > float.Epsilon)
        {
            Vector3 forward = cameraHorizontalRotator.forward;
            transform.localPosition = transform.localPosition + playerY * forward * playerSpeedForward * Time.deltaTime;
        }

    }
}
