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
        public int maxNumberOfClones = 4;

        protected CharacterController2D controller2D;
        private float lastValue = 0f;
        private bool isJumping = false;
        private bool Primal = true;
        private static CharacterMovement PrimalObj;
        private static int cloneCount = 1;

        public void OnDuplicate(InputAction.CallbackContext context)
        {
            if (Primal && cloneCount < maxNumberOfClones)
            {
                var gameObj = Instantiate(gameObject, transform.position, transform.rotation);
                var movement = gameObj.GetComponent<CharacterMovement>();
                movement.Primal = false;
                PrimalObj = this;
                cloneCount++;
                transform.position += Vector3.up * transform.localScale.y * 0.5f;

                controller2D.ForceJump();
            }
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
            controller2D = GetComponent<CharacterController2D>();
            CharacterInputHandler.SetCallback(this);
            if (Primal)
                PrimalObj = this;
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
