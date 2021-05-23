﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLevelLoader : MonoBehaviour
{
    private static GameLevelLoader Instance;

    public List<Level> levels;
    public int currentLevelIndex = 0;
    private Level currentLevel;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            currentLevel = levels[currentLevelIndex];
            currentLevel?.gameObject.SetActive(true);
        } else
        {
            Destroy(Instance);
        }
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    public static void _LoadNextLevel()
    {
        if (Instance !=null)
        {
            Instance.LoadNextLevel();
        }
    }

    public static void _ReLoadLevel()
    {
        if (Instance != null)
        {
            Instance.ReLoadLevel();
        }
    }

    private void ReLoadLevel()
    {
        currentLevel?.gameObject.SetActive(false);
        Debug.Log(currentLevel?.gameObject.name + " Unload");
        currentLevel?.gameObject.SetActive(true);
        Debug.Log(currentLevel?.gameObject.name + " ReLoaded");
    }

    private void LoadNextLevel()
    {
        currentLevel?.gameObject.SetActive(false);
        Debug.Log(currentLevel?.gameObject.name + " Unload");
        currentLevelIndex++;
        if (currentLevelIndex < levels.Count)
        {
            currentLevel = levels[currentLevelIndex];
            Debug.Log(currentLevel?.gameObject.name + " Loaded");
            currentLevel?.gameObject.SetActive(true);
        } else
        {
            currentLevel?.gameObject.SetActive(true);
            Debug.Log(currentLevel?.gameObject.name + " ReLoaded");
        }
    }
}