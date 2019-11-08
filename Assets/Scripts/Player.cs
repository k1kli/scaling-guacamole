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
    }
    void CameraMovement()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        if (Mathf.Abs(mouseX) > float.Epsilon)
        {
            cameraHorizontalRotator.Rotate(0.0f, mouseX * cameraSpeedX * Time.unscaledDeltaTime, 0.0f);
        }
        if (Mathf.Abs(mouseY) > float.Epsilon)
        {
            cameraTransform.Rotate(-mouseY * cameraSpeedY * Time.unscaledDeltaTime, 0.0f, 0.0f);
        }
        timeController.SetCameraRotationInfluence(mouseX, mouseY);
    }
    void PlayerMovement()
    {
        Vector2 movement;
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        if(movement.sqrMagnitude > 1f)
        {
            movement.Normalize();
        }
        if (Mathf.Abs(movement.x) > float.Epsilon)
        {
            Vector3 right = cameraHorizontalRotator.right;
            body.AddForce(movement.x * right * playerSpeedSideways);
            //transform.localPosition = transform.localPosition + playerX * right * playerSpeedSideways * Time.deltaTime;
        }
        if (Mathf.Abs(movement.y) > float.Epsilon)
        {
            Vector3 forward = cameraHorizontalRotator.forward;
            body.AddForce(movement.y * forward * playerSpeedForward);
            //transform.localPosition = transform.localPosition + playerY * forward * playerSpeedForward * Time.deltaTime;
        }
        timeController.SetMovementInfluence(movement.magnitude);
        cameraHorizontalRotator.position = bodyTransform.position + cameraRelativePos;
    }
}
