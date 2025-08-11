using UnityEngine;
using UnityEngine.InputSystem;

namespace NewInputSystem
{
    public class PlayerController3 : MonoBehaviour
    {
        private CharacterController cc;

        public float speed = 5f;

        private Vector3 moveInput;

        void Start()
        {
            cc = GetComponent<CharacterController>();
        }

        void Update()
        {
            cc.Move(moveInput * speed * Time.deltaTime);
        }

        private void OnMove(InputValue value)
        {
            Vector2 dir =  value.Get<Vector2>();
            
            moveInput = new Vector3(dir.x, 0, dir.y);
        }
        
        private void OnJump(InputValue value)
        {
            bool isJump = value.isPressed;
            Debug.Log(isJump);
        }
        
        private void OnInteraction(InputValue value)
        {
            bool isInteraction = value.isPressed;
            Debug.Log(isInteraction);
        }
        
        private void OnAttack(InputValue value)
        {
            Debug.Log("OnAttack");
        }
    }
}