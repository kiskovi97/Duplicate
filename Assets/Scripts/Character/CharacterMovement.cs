using Assets.Scripts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Assets.Scripts.Character
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(CharacterController2D))]
    public class CharacterMovement : MonoBehaviour, CharacterControls.ICharacterActions
    {
        public float maxSpeed = 10f;

        internal void DestoryPlayer()
        {
            clones.Remove(gameObject);
            Destroy(gameObject);
        }

        internal static void Reset()
        {
            foreach (var gameObject in clones)
            {
                Destroy(gameObject);
            }
            clones.Clear();
        }

        public float jumpForce = 10f;
        public static int maxNumberOfClones = 3;

        protected CharacterController2D controller2D;
        private float lastValue = 0f;
        private bool isJumping = false;
        private bool Primal = true;
        private static CharacterMovement PrimalObj;
        private static float maxDistance = 10f;
        public UnityEngine.Experimental.Rendering.Universal.Light2D primalLight;
        private static int CloneCount => clones.Count;

        public bool IsPrime => Primal;
        public static CharacterMovement PrimeObject => PrimalObj;
        public static List<GameObject> clones = new List<GameObject>();

        public Animator animator;

        public GameObject cloneImage;
        public Transform clonePanel;
        public Transform centerPosition;

        public void OnDuplicate(InputAction.CallbackContext context)
        {
            if (Primal && CloneCount < maxNumberOfClones)
            {
                var gameObj = Instantiate(gameObject, transform.position, transform.rotation);
                var movement = gameObj.GetComponent<CharacterMovement>();
                movement.Primal = false;
                PrimalObj = this;
                clones.Add(gameObj);
                transform.position += Vector3.up * transform.localScale.y * 0.5f;

                controller2D.ForceJump();

                animator.SetTrigger("CloneUp");
                movement.animator.SetTrigger("CloneDown");
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

        private void Update()
        {
            if (clonePanel != null)
            {
                var diffrence = clonePanel.childCount - (maxNumberOfClones - clones.Count);
                if (diffrence > 0)
                {
                    Destroy(clonePanel.GetChild(0).gameObject);
                }
                if (diffrence < 0)
                {
                    Instantiate(cloneImage, clonePanel);
                }
            }
            if (primalLight != null)
            {
                primalLight.enabled = Primal;
            }

            if (centerPosition != null && Primal)
            {
                if (clones.Count > 0)
                {
                    Vector3 localGoal = Vector3.zero;
                    foreach (var localPosition in clones.Select(clone => clone.transform.position - transform.position))
                    {
                        var pos = localPosition;
                        if (pos.magnitude > maxDistance)
                        {
                            pos = pos.normalized * maxDistance;
                        }
                        localGoal += pos / clones.Count;
                    }

                    localGoal /= 2f;
                    var positionGoal = localGoal + transform.position;
                    Debug.DrawLine(transform.position, positionGoal, Color.red);
                    centerPosition.position = positionGoal;
                    //centerPosition.position + (positionGoal - centerPosition.position).normalized * Time.deltaTime;
                }
                else
                {
                    centerPosition.position = transform.position;
                }
            } 
        }

        private void FixedUpdate()
        {
            var speed = maxSpeed * lastValue * Time.fixedDeltaTime;
            //if ((speed > 0f && rigidbody2D.velocity.x < 0f) || (speed < 0f && rigidbody2D.velocity.x > 0f))
            //    rigidbody2D.velocity = new Vector2(0f, rigidbody2D.velocity.y);
            //rigidbody2D.AddForce(Vector2.right * speed * Time.fixedDeltaTime, ForceMode2D.Impulse);
            controller2D.Move(speed, false, isJumping);
            animator.SetBool("OnGround", controller2D.OnGround);
            var info = animator.GetCurrentAnimatorStateInfo(0);

            animator.speed = Mathf.Abs(info.IsName("Walking") ? speed : 3f);
            isJumping = false;
        }

        void OnDestroy()
        {
            CharacterInputHandler.RemoveCallback(this);
        }
    }
}
