using Assets.Scripts.Character;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
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
    public GameObject firstPanelFirstButton;
    public Text levelNameText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            firstPanel.SetActive(true);
            if (firstPanelFirstButton != null)
            {
                EventSystem.current.SetSelectedGameObject(null);
                EventSystem.current.SetSelectedGameObject(firstPanelFirstButton);
            }
            CharacterMovement.IsPlaying = false;
        }
        else
        {
            Destroy(Instance);
        }
    }

    public void StartNew()
    {
        currentLevelIndex = 0;
        LoadLevel(currentLevelIndex);
    }

    public void ResumeLast()
    {
        currentLevelIndex = 0;
        var score = DatabaseTables.scoreTable.GetById(GameplayController.userName);
        if (score != null)
        {
            currentLevelIndex = (int)score.score;
        }
        LoadLevel(currentLevelIndex);
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

    private void LoadNextLevel()
    {
        currentLevel?.gameObject.SetActive(false);
        Debug.Log(currentLevel?.gameObject.name + " Unload");
        currentLevelIndex++;
        if (currentLevelIndex < levels.Count)
        {
            LoadLevel(currentLevelIndex);
        }
        else
        {
            GameOver();
        }
    }

    private void LoadLevel(int index)
    {
        firstPanel.SetActive(false);
        if (levelNameText != null)
            levelNameText.text = "Level " + (index + 1).ToString();

        GameplayController.score = index;
        currentLevel = levels[index];
        Debug.Log(currentLevel?.gameObject.name + " Loaded");
        currentLevel?.gameObject.SetActive(true);
        currentLevel.Load();
    }

    private void ReLoadLevel()
    {
        firstPanel.SetActive(false);
        currentLevel?.gameObject.SetActive(false);
        Debug.Log(currentLevel?.gameObject.name + " Unload");
        currentLevel?.gameObject.SetActive(true);
        Debug.Log(currentLevel?.gameObject.name + " ReLoaded");
        currentLevel.Load();
    }

    public void GameOver()
    {
        CharacterMovement.IsPlaying = false;
        currentLevel?.gameObject.SetActive(true);
        Debug.Log(currentLevel?.gameObject.name + " ReLoaded");
        controller.ExitClicked();
    }
}
