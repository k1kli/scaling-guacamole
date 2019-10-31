using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform camera;
    public Transform cameraHorizontalRotator;
    public float speedX = 5.0f;
    public float speedY = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");
        if(Mathf.Abs(x) > float.Epsilon)
        {
            cameraHorizontalRotator.Rotate(0.0f, x * speedX*Time.deltaTime, 0.0f);
        }
        if (Mathf.Abs(y) > float.Epsilon)
        {
            camera.Rotate(-y * speedY * Time.deltaTime, 0.0f, 0.0f);
        }
    }
}
