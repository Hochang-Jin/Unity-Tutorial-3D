using System;
using UnityEngine;

public class FPSPlayerMove : MonoBehaviour
{
    // 이동 속도 변수
    public float moveSpeed = 7f;
    // 캐릭터 컨트롤러 변수
    private CharacterController cc;

    // 중력 변수
    private float gravity = -20f;
    // 수직 속력 변수
    private float yVelocity = 0f;
    // 점프력 변수
    private float jumpPower = 10f;
    // 점프 상태 변수
    public bool isJumping = false;
    
    private void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    private void Update()
    {
         // 1. 사용자 입력 받기
         float h = Input.GetAxis("Horizontal");
         float v = Input.GetAxis("Vertical");
         
         // 2. 이동 방향 설정
         Vector3 dir = new Vector3(h, 0, v);
         dir = dir.normalized;
         
         // 2-1. 카메라 기준으로 방향 변환
         dir = Camera.main.transform.TransformDirection(dir);
         
         // 2-2. 점프 기능
         if (cc.collisionFlags == CollisionFlags.Below)
         {
             if (isJumping)
             {
                 isJumping = false;
                 yVelocity = 0;
             }
         }
         
         if (Input.GetButtonDown("Jump") && !isJumping)
         {
             yVelocity = jumpPower;
             isJumping = true;
         }
         
         // 2-3. 캐릭터 수직 속도에 중력 값을 적용한다.
         yVelocity += gravity * Time.deltaTime;
         dir.y = yVelocity;
         
         // 3. 이동 속도에 맞춰 이동
         // transform.position += dir * (moveSpeed * Time.deltaTime);
         cc.Move(dir * (moveSpeed * Time.deltaTime));
    }
}
