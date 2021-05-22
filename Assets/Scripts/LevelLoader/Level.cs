using Assets.Scripts.Character;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public Transform startDoor;

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
    }

    internal void Load()
    {
        if (CharacterMovement.PrimeObject != null)
            CharacterMovement.PrimeObject.transform.position = startDoor.position;
    }
}
