using Assets.Scripts.Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishDoor : Obstacle
{
    protected override void DoPrime(CharacterMovement collision)
    {
        base.DoPrime(collision);
        GameLevelLoader._LoadNextLevel();
    }
}
