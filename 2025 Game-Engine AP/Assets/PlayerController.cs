using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpPower = 5f;
    public float gravity = -9.8f;

    private CharacterController controller;
    private Vector3 velocity;
    public bool isGrounded;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        isGrounded = controller.isGrounded;

        // Grounded 상태에서 아래로 계속 떨어지지 않도록 보정
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // 살짝 눌러주는 값
        }

        // 이동 입력
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(x, 0, z);
        controller.Move(move * speed * Time.deltaTime);

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

