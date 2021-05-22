using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLevelLoader : MonoBehaviour
{
    private static GameLevelLoader Instance;

    public List<Level> levels;
    private int index = 0;
    private Level currentLevel;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            currentLevel = levels[index];
            //currentLevel?.gameObject.SetActive(true);
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

    private void LoadNextLevel()
    {
        currentLevel?.gameObject.SetActive(false);
        Debug.Log(currentLevel?.gameObject.name + " Unload");
        index++;
        if (index < levels.Count)
        {
            currentLevel = levels[index];
            Debug.Log(currentLevel?.gameObject.name + " Loaded");
            currentLevel?.gameObject.SetActive(true);
        } else
        {
            currentLevel?.gameObject.SetActive(true);
            Debug.Log(currentLevel?.gameObject.name + " ReLoaded");
        }
    }
}
