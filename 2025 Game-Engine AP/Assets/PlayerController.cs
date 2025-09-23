using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpPower = 5f;
    public float gravity = -9.8f;
    
    public CinemachineVirtualCamera virtualCam;
    public float rotationSpeed = 10f;
    private CharacterController controller;
    private CinemachinePOV pov;
    private Vector3 velocity;
    public bool isGrounded;
    public CInemachineSwitcher switcher;
    float x = 0f;
    float z = 0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        pov = virtualCam.GetCinemachineComponent<CinemachinePOV>();
    }

    void Update()
    {
        isGrounded = controller.isGrounded;

       
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; 
        }


        if (!freeLookOn)
        {
            x = Input.GetAxis("Horizontal");
            z = Input.GetAxis("Vertical");
        }
        if(GetKeyDown(LeftShift))
        {
            speed = 20f;
            virtualCam.m_Lens.FieldOfView = 60f;
        }
        else
        {
            speed = 5f;
            virtualCam.m_Lens.FieldOfView = 40f;
        }

            Vector3 camForward = virtualCam.transform.forward;
        camForward.y = 0;
        camForward.Normalize();

        Vector3 camRight = virtualCam.transform.right;
        camRight.y = 0;
        camRight.Normalize();

        Vector3 move = (camForward * z + camRight * x).normalized;
        controller.Move(move * speed * Time.deltaTime);

        float cameraYaw = pov.m_HorizontalAxis.Value;
        Quaternion targetRot = Quaternion.Euler(0f, cameraYaw, 0f);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, rotationSpeed * Time.deltaTime);
        
        
       
        

        // 점프 입력
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            velocity.y = jumpPower;
        }

        // 중력 적용
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}

