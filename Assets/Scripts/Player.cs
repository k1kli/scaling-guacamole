using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : DamageTaker
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
    private float reloadProgress = 0.0f;
    public float reloadTime = 0.3f;


    private bool cameraRotation = false;
    private bool playerMove = false;
    public Bullet bulletPrefab;

    private void OnEnable()
    {
        body = bodyTransform.GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        Init(20);
        cameraRelativePos = cameraHorizontalRotator.position - bodyTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        CameraMovement();
        timeController.SetTimescale(cameraRotation, playerMove);
        reloadProgress += Time.deltaTime;
        if (Input.GetMouseButton(0))
        {
            StartCoroutine(Shoot());
        }

    }
    private void FixedUpdate()
    {

    }
    void CameraMovement()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        cameraRotation = false;
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
    }
    void PlayerMovement()
    {
        Vector2 movement;
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        if (movement.sqrMagnitude > 1f)
            movement.Normalize();
        playerMove = false;
        if (Mathf.Abs(movement.x) > float.Epsilon)
        {
            Vector3 right = cameraHorizontalRotator.right;
            body.AddForce(movement.x * right * playerSpeedSideways);
            playerMove = true;
        }
        if (Mathf.Abs(movement.y) > float.Epsilon)
        {
            Vector3 forward = cameraHorizontalRotator.forward;
            body.AddForce(movement.y * forward * playerSpeedForward);
            playerMove = true;
        }
        cameraHorizontalRotator.position = bodyTransform.position + cameraRelativePos;
    }
    IEnumerator Shoot()
    {
        while(reloadProgress >= reloadTime)
        {
            Bullet bullet = GameObject.Instantiate<Bullet>(bulletPrefab);
            bullet.transform.localPosition = cameraTransform.position + cameraTransform.forward * 0.7f;
            bullet.Init(cameraTransform.forward);
            reloadProgress =0;
        }
        yield return null;
    }
    public override void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
