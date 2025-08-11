using UnityEngine;
using UnityEngine.InputSystem;

namespace Farm
{
    public class PlayerController : MonoBehaviour
    {
        private Animator anim;

        private PlayerInput playerInput;

        private CharacterController cc;
        private Vector3 moveInput;

        [SerializeField] private float moveSpeed = 2f;
        [SerializeField] private float turnSpeed = 10f;

        void Start()
        {
            anim = GetComponent<Animator>();
            cc = GetComponent<CharacterController>();
        }

        void Update()
        {
            cc.Move(moveInput * moveSpeed * Time.deltaTime);

            Turn();
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
        
    }
}