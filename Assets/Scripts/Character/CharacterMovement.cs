using Assets.Scripts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.Character
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(CharacterController2D))]
    class CharacterMovement : MonoBehaviour, CharacterControls.ICharacterActions
    {
        public float maxSpeed = 10f;
        public float jumpForce = 10f;

        protected new Rigidbody2D rigidbody2D;
        protected CharacterController2D controller2D;
        private float lastValue = 0f;
        private bool isJumping = false;

        public void OnDuplicate(InputAction.CallbackContext context)
        {
            throw new NotImplementedException();
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            isJumping = true;
        }

        public void OnMovement(InputAction.CallbackContext context)
        {
            lastValue = context.ReadValue<float>();
        }

        void Start()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
            controller2D = GetComponent<CharacterController2D>();
            CharacterInputHandler.SetCallback(this);
        }

        private void FixedUpdate()
        {
            var speed = maxSpeed * lastValue * Time.fixedDeltaTime;
            //if ((speed > 0f && rigidbody2D.velocity.x < 0f) || (speed < 0f && rigidbody2D.velocity.x > 0f))
            //    rigidbody2D.velocity = new Vector2(0f, rigidbody2D.velocity.y);
            //rigidbody2D.AddForce(Vector2.right * speed * Time.fixedDeltaTime, ForceMode2D.Impulse);

            controller2D.Move(speed, false, isJumping);
            isJumping = false;
        }

        void OnDestroy()
        {
            CharacterInputHandler.RemoveCallback(this);
        }
    }
}
