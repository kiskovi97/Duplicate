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
        if (player != null && player.IsPrime && !collided)
        {
            if (player.IsPrime)
            {
                DoPrime();
            }
            DoAnyCollision();
            collided = true;
        }
    }

    void Update()
    {
        collided = false;
    }

    protected virtual void DoAnyCollision()
    {
    }

    protected virtual void DoPrime()
    {
    }
}
