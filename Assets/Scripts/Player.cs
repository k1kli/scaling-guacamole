using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform cameraTransform;
    public Transform cameraHorizontalRotator;
    public Transform bodyTransform;
    public float cameraSpeedX = 300.0f;
    public float cameraSpeedY = 300.0f;
    public float playerSpeedForward = 2.0f;
    public float playerSpeedSideways = 2.0f;
    public TimeController timeController;
    private Rigidbody body;
    private Vector3 cameraRelativePos;

    private bool cameraRotation = false;
    private bool playerMove = false;    
    private void OnEnable()
    {
        body = bodyTransform.GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        cameraRelativePos = cameraHorizontalRotator.position - bodyTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        CameraMovement();
        
    }
    private void FixedUpdate()
    {
        PlayerMovement();
        timeController.SetTimescale(cameraRotation, playerMove);
    }
    void CameraMovement()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        if (Mathf.Abs(mouseX) > float.Epsilon)
        {
            cameraHorizontalRotator.Rotate(0.0f, mouseX * cameraSpeedX * Time.unscaledDeltaTime, 0.0f);
            cameraRotation = true;
        }
        if (Mathf.Abs(mouseY) > float.Epsilon)
        {
            cameraTransform.Rotate(-mouseY * cameraSpeedY * Time.unscaledDeltaTime, 0.0f, 0.0f);
            cameraRotation = true;
        }
        else if (!(Mathf.Abs(mouseX) > float.Epsilon))
                cameraRotation = false;
    }
    void PlayerMovement()
    {
        float playerX = Input.GetAxis("Horizontal");
        float playerY = Input.GetAxis("Vertical");
        if (Mathf.Abs(playerX) > float.Epsilon)
        {
            Vector3 right = cameraHorizontalRotator.right;
            body.AddForce(playerX * right * playerSpeedSideways);
            playerMove = true;
            //transform.localPosition = transform.localPosition + playerX * right * playerSpeedSideways * Time.deltaTime;
        }
        if (Mathf.Abs(playerY) > float.Epsilon)
        {
            Vector3 forward = cameraHorizontalRotator.forward;
            body.AddForce(playerY * forward * playerSpeedForward);
            playerMove = true;
            //transform.localPosition = transform.localPosition + playerY * forward * playerSpeedForward * Time.deltaTime;
        }
        else if (!(Mathf.Abs(playerX) > float.Epsilon))
            playerMove = false;
        cameraHorizontalRotator.position = bodyTransform.position + cameraRelativePos;
    }
}
