using Assets.Scripts.Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : Obstacle
{
    protected override void DoPrime(CharacterMovement player)
    {
        base.DoPrime(player);
        GameLevelLoader._ReLoadLevel();
    }

    protected override void NotPrime(CharacterMovement player)
    {
        base.NotPrime(player);
        player.DestoryPlayer();
    }
}
