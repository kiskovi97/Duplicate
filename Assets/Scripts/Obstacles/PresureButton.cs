using Assets.Scripts.Character;

namespace Assets.Scripts.Obstacles
{
    class PresureButton : Obstacle
    {
        public Door door;
        protected override void DoAnyCollision(CharacterMovement player)
        {
            base.DoAnyCollision(player);
            door.Open();
        }

        protected override void DoAnyCollisionExit(CharacterMovement player)
        {
            base.DoAnyCollisionExit(player);
            door.Close();
        }
    }
}
