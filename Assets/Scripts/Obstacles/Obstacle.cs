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
            } else
            {
                NotPrime(player);
            }
            DoAnyCollision(player);
            collided = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var player = collision.gameObject.GetComponent<CharacterMovement>();
        if (player != null && !collided)
        {
            if (player.IsPrime)
            {
                DoPrimeExit(player);
            } else
            {
                NotPrimeExit(player);
            }
            DoAnyCollisionExit(player);
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

    protected virtual void NotPrime(CharacterMovement player)
    {
    }


    protected virtual void DoAnyCollisionExit(CharacterMovement player)
    {
    }

    protected virtual void DoPrimeExit(CharacterMovement player)
    {
    }

    protected virtual void NotPrimeExit(CharacterMovement player)
    {
    }
}
