﻿using Assets.Scripts.Character;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using URPTemplate.Database;
using URPTemplate.UI;

public class GameLevelLoader : MonoBehaviour
{
    private static GameLevelLoader Instance;

    public List<Level> levels;
    public int currentLevelIndex = 0;
    private Level currentLevel;

    public static event Action OnReset;
    public GameplayController controller;

    public GameObject firstPanel;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            firstPanel.SetActive(true);
            CharacterMovement.IsPlaying = false;
        } else
        {
            Destroy(Instance);
        }
    }

    public void StartNew()
    {
        currentLevelIndex = 0;
        firstPanel.SetActive(false);

        currentLevel = levels[currentLevelIndex];
        currentLevel?.gameObject.SetActive(true);
        GameplayController.score = currentLevelIndex;
        CharacterMovement.maxNumberOfClones = 0;
        currentLevel.Load();
    }

    public void ResumeLast()
    {
        currentLevelIndex = 0;
        firstPanel.SetActive(false);
        var score = DatabaseTables.scoreTable.GetById(GameplayController.userName);
        if (score != null)
        {
            currentLevelIndex = (int)score.score;
        }

        currentLevel = levels[currentLevelIndex];
        currentLevel?.gameObject.SetActive(true);
        GameplayController.score = currentLevelIndex;
        CharacterMovement.maxNumberOfClones = 0;
        currentLevel.Load();
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
        if (Instance != null)
        {
            Instance.LoadNextLevel();
        }
        OnReset?.Invoke();
    }

    public static void _ReLoadLevel()
    {
        if (Instance != null)
        {
            Instance.ReLoadLevel();
        }
        OnReset?.Invoke();
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
            GameplayController.score = currentLevelIndex;
            currentLevel = levels[currentLevelIndex];
            Debug.Log(currentLevel?.gameObject.name + " Loaded");
            currentLevel?.gameObject.SetActive(true);
        } else
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        CharacterMovement.IsPlaying = false;
        currentLevel?.gameObject.SetActive(true);
        Debug.Log(currentLevel?.gameObject.name + " ReLoaded");
        controller.ExitClicked();
    }
}
