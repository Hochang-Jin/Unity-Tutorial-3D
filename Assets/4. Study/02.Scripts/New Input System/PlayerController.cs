using UnityEngine;
using UnityEngine.InputSystem;

namespace NewInputSystem
{


    public class PlayerController : MonoBehaviour
    {
        private CharacterController cc;

        private Vector2 moveInput;
        public float speed = 5f;

        public InputActionAsset inputActionAsset;

        private InputAction moveAction;
        private InputAction jumpAction;
        private InputAction interactionAction;
        private InputAction attackAction;


        void Start()
        {
            moveAction = inputActionAsset.FindAction("Move");
            jumpAction = inputActionAsset.FindAction("Jump");
            attackAction = inputActionAsset.FindAction("Attack");
            interactionAction = inputActionAsset.FindAction("Interaction");

            cc = GetComponent<CharacterController>();
        }

        void Update()
        {
            moveInput = moveAction.ReadValue<Vector2>();

            if (moveInput != Vector2.zero)
            {
                Debug.Log("Move : " + moveAction.ReadValue<Vector2>());
                var dir = new Vector3(moveInput.x, 0, moveInput.y);

                cc.Move(dir * speed * Time.deltaTime);
            }

            if (jumpAction.IsPressed())
            {
                Debug.Log("Jump");
            }

            if (attackAction.IsPressed())
            {
                Debug.Log("Attack");
            }

            if (interactionAction.IsPressed())
            {
                Debug.Log("Interaction");
            }

        }
    }
}