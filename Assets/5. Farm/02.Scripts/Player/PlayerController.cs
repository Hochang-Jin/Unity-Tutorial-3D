using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace Farm
{
    public class PlayerController : MonoBehaviour
    {
        private Animator anim;

        private CharacterController cc;
        private Vector3 moveInput;

        [SerializeField] private float walkSpeed = 2f;
        [SerializeField] private float runSpeed = 8f;
        [SerializeField] private float turnSpeed = 10f;
        
        private Vector3 velocity;
        private const float GRAVITY = -9.8f;
        
        private float currentSpeed;
        private bool isRun;

        void Start()
        {
            anim = GetComponent<Animator>();
            cc = GetComponent<CharacterController>();
        }

        void Update()
        {
            velocity += GRAVITY * Vector3.up;

            var dir = moveInput * currentSpeed + velocity;
            
            cc.Move(dir * Time.deltaTime);

            Turn();
            SetAnimation();

        }
        
        private void OnMove(InputValue value)
        {
            var move = value.Get<Vector2>();
            moveInput = new Vector3(move.x, 0, move.y);
            
        }

        private void Turn()
        {
            if (moveInput != Vector3.zero)
            {
                // 특정 방향을 바라보는 기능
                Quaternion targetRot = Quaternion.LookRotation(moveInput);
                
                //  현재 회전            목표 회전            비율 (속도)
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, turnSpeed * Time.deltaTime);
            }
        }

        private void OnRun(InputValue value)
        {
            isRun = value.isPressed;
        }
        
        private void SetAnimation()
        {
            float targetValue = 0f;
            if (moveInput != Vector3.zero)
            {
                targetValue = isRun ? 1f : 0.5f;
                currentSpeed = isRun ? runSpeed : walkSpeed;
            }
            float animValue = anim.GetFloat("Move");
            
            animValue = Mathf.Lerp(animValue, targetValue, 10f * Time.deltaTime);
            
            anim.SetFloat("Move", animValue);
        }
    }
}