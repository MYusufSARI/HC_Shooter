using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState { Menu, Game, LevelComplete, GameOver }

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header(" Settings ")]
    private GameState gameState;

    [Header(" Actions ")]
    public static Action<GameState> onGameStateChanged;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        else
        {
            Destroy(gameObject);
        }
    }


    private void Start()
    {
        SetGameState(GameState.Menu);
    }


    public void SetGameState(GameState gameState)
    {
        this.gameState = gameState;
        onGameStateChanged?.Invoke(gameState);
    }


    public bool IsGameState()
    {
        return gameState == GameState.Game;
    }


    public void Retry()
    {
        SceneManager.LoadScene(0);
    }

    public void NextLevel()
    {
        // Tell the level manager to increase the level index!
        SceneManager.LoadScene(0);
    }
}
