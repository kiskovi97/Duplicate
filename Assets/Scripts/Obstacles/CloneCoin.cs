using Assets.Scripts.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Obstacles
{
    class CloneCoin : Obstacle
    {
        protected override void DoAnyCollision(CharacterMovement player)
        {
            base.DoAnyCollision(player);
            CharacterMovement.maxNumberOfClones++;
            Destroy(gameObject);
        }
    }
}
