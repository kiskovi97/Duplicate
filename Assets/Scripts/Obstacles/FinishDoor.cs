using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishDoor : Obstacle
{
    protected override void DoPrime()
    {
        base.DoPrime();
        GameLevelLoader._LoadNextLevel();
    }
}
