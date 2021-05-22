using Assets.Scripts.Character;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Obstacle : MonoBehaviour
{
    private bool collided = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.gameObject.GetComponent<CharacterMovement>();
        if (player != null && !collided)
        {
            if (player.IsPrime)
            {
                DoPrime(player);
            }
            DoAnyCollision(player);
            collided = true;
        }
    }

    void Update()
    {
        collided = false;
    }

    protected virtual void DoAnyCollision(CharacterMovement player)
    {
    }

    protected virtual void DoPrime(CharacterMovement player)
    {
    }
}
