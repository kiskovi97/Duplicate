using Assets.Scripts.Character;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public Transform startDoor;
    public int minimumCloneCount = 0;

    void OnEnable()
    {
        Load();
    }

    void OnDisable()
    {
        UnLoad();
    }

    private void UnLoad()
    {
        CharacterMovement.IsPlaying = false;
        CharacterMovement.Reset(0);
    }

    internal void Load()
    {
        if (CharacterMovement.PrimeObject != null)
        {
            CharacterMovement.PrimeObject.transform.position = startDoor.position;
            CharacterMovement.Reset(minimumCloneCount);
            CharacterMovement.IsPlaying = true;
        }
    }
}
