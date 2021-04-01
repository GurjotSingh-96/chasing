using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPController : MonoBehaviour

{

    public Transform cam;
    float camRotation = 0f;
    public float speed = 10f;
    public float mouseSensitivity = 2f;
    public float gravity = -15f;
    CharacterController cc;
    float y = 0f;
    public float jumpSpeed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponentInChildren<Camera>().transform;
        cc = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void OnDestroy()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        DoMovement();
        DoLook();
    }

    private void DoMovement()
    {
        //get Input
        float x = Input.GetAxis("Horizontal"); 
        float z = Input.GetAxis("Vertical");

        Vector3 move = (x * transform.right) + (z * transform.forward);
        move = Vector3.ClampMagnitude(move, 1f);
        move.y = y;

    // move it
        cc.Move(move * Time.deltaTime);
        if (cc.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                y = jumpSpeed;
            }
            else 
            {
                y = gravity * Time.deltaTime;
            }
        }
        else 
        {
            //apply gravity
            y += gravity * Time.deltaTime;
        }

    }

        void DoLook()
    {
        float xMouse = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(0, xMouse, 0);
        camRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        camRotation = Mathf.Clamp(camRotation, -80f, 80f);
        cam.localRotation = Quaternion.Euler(camRotation, 0, 0); 

    }


}
