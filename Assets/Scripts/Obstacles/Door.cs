using Assets.Scripts.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Obstacles
{
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(Animator))]
    class Door : MonoBehaviour
    {
        private new Collider2D collider;
        private Animator animator;
        public bool leftToRightClose = true;


        private void OnCollisionEnter2D(Collision2D collision)
        {
            var player = collision.gameObject.GetComponent<CharacterMovement>();
            var isCenter = collision.contacts.Sum(coll => coll.normal.y) > 0f;
            if (player != null && isCenter)
            {
                GameLevelLoader._ReLoadLevel();
            }
        }

        private void Awake()
        {
            collider = GetComponent<Collider2D>();
            animator = GetComponent<Animator>();
        }

        public void Open()
        {
            collider.enabled = false;
            animator.SetTrigger("Open");
        }

        public void Close()
        {
            collider.enabled = true;
            animator.SetTrigger("Close");
        }
    }
}
