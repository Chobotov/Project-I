using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ProjectI.Game.Player
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Move settings")]
        [SerializeField] private float speed;
        [SerializeField] private float jumpForce;
        [SerializeField] private float groundHeight; 
        [Header("Stats")] 
        [SerializeField] private bool isGround;

        private Controls.Controls controls;

        private Rigidbody rigidbody;

        private IMoveble moveble;
        
        private float moveInput;

        private void Awake()
        {
            rigidbody = GetComponent<Rigidbody>();

            moveble = new MarioMoveBehaviour();
            controls = new Controls.Controls();
        }

        private void OnEnable()
        {
            controls.Main.Jump.performed += Jump;

            controls.Enable();
        }

        private void OnDisable()
        {
            controls.Main.Jump.performed -= Jump;

            controls.Disable();
        }

        private void HandleGravity()
        {
            
        }
        
        private void Jump(InputAction.CallbackContext obj)
        {
            if (isGround)
            {
                moveble.Jump(jumpForce);
            }
        }

        private void CheckGround()
        {
            isGround = Physics.Raycast(transform.position, Vector3.down, groundHeight);
        }
        
        private void FixedUpdate()
        {
            CheckGround();

            moveInput = controls.Main.Move.ReadValue<float>();

            moveble.Move(moveInput, speed);
        }
    }
}