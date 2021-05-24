using Assets.Scripts.Character;

namespace Assets.Scripts.Obstacles
{
    class Sacrefice : Obstacle
    {
        public Door door;
        protected override void DoPrime(CharacterMovement player)
        {
            base.DoPrime(player);
            GameLevelLoader._ReLoadLevel();
        }

        protected override void NotPrime(CharacterMovement player)
        {
            base.NotPrime(player);
            player.DestoryPlayer();
            door.Open();
        }

        private void Awake()
        {
            GameLevelLoader.OnReset += GameLevelLoader_OnReset;
        }

        private void GameLevelLoader_OnReset()
        {
            door.Close();
        }
    }
}
