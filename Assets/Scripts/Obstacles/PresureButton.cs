using Assets.Scripts.Character;
using UnityEngine;

namespace Assets.Scripts.Obstacles
{
    class PresureButton : Obstacle
    {
        public Door door;
        private int inside = 0;

        private Animator animator;
        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        protected override void DoAnyCollision(CharacterMovement player)
        {
            base.DoAnyCollision(player);
            inside++;
            door.Open();
            if (animator != null)
                animator.SetTrigger("Open");
        }

        protected override void DoAnyCollisionExit(CharacterMovement player)
        {
            base.DoAnyCollisionExit(player);
            inside--;
            if (inside <= 0)
            {
                door.Close();
                if (animator != null)
                    animator.SetTrigger("Close");
            }
        }
    }
}
