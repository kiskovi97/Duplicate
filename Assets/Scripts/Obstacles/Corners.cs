using Assets.Scripts.Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corners : Obstacle
{
    protected override void DoPrime(CharacterMovement player)
    {
        base.DoPrime(player);
        GameLevelLoader._ReLoadLevel();
    }

    protected override void DoAnyCollision(CharacterMovement player)
    {
        base.DoAnyCollision(player);
        if (!player.IsPrime)
        {
            player.DestoryPlayer();
        }
        
    }
}
