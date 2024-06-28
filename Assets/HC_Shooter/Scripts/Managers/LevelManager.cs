using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private GameObject[] levels;
    private int levelIndex;

    private const string LEVEL = "Level";



    private void Awake()
    {
        LoadData();

        SpawnLevel();

        GameManager.onGameStateChanged += GameStateChangedCallback;
    }


    private void OnDestroy()
    {
        GameManager.onGameStateChanged -= GameStateChangedCallback;
    }


    private void Start()
    {
        
    }


    private void GameStateChangedCallback(GameState gameState)
    {
        switch (gameState)
        {
            case GameState.LevelComplete:
                levelIndex++;
                SaveData();
                break;
        }
    }


    private void SpawnLevel()
    {
        if (levelIndex >= levels.Length)
        {
            levelIndex = 0;
        }

        GameObject levelInstance = Instantiate(levels[levelIndex], transform);

        StartCoroutine(EnableLevelCoroutine());

        IEnumerator EnableLevelCoroutine()
        {
            yield return new WaitForSeconds(Time.deltaTime);
            levelInstance.SetActive(true);
        }
    }


    private void LoadData()
    {
        levelIndex = PlayerPrefs.GetInt(LEVEL);
    }


    private void SaveData()
    {
        PlayerPrefs.SetInt(LEVEL, levelIndex);
    }


}
