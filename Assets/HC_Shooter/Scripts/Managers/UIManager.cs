using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header(" Panels ")]
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private GameObject levelCompletePanel;
    [SerializeField] private GameObject gameOverPanel;



    private void Awake()
    {
        GameManager.onGameStateChanged += GameStateChangedCallback;
    }


    private void OnDestroy()
    {
        GameManager.onGameStateChanged -= GameStateChangedCallback;
    }


    private void Start()
    {

    }


    private void Update()
    {

    }


    private void GameStateChangedCallback(GameState gameState)
    {
        switch (gameState)
        {
            case GameState.Menu:
                menuPanel.SetActive(true);
                gamePanel.SetActive(false);
                levelCompletePanel.SetActive(false);
                gameOverPanel.SetActive(false);
                break;

            case GameState.Game:
                menuPanel.SetActive(false);
                gamePanel.SetActive(true);
                break;

            case GameState.LevelComplete:
                gamePanel.SetActive(false);
                levelCompletePanel.SetActive(true);
                break;

            case GameState.GameOver:
                gamePanel.SetActive(false);
                gameOverPanel.SetActive(true);
                break;

        }
    }


    public void PlayButtonCallback()
    {
        GameManager.instance.SetGameState(GameState.Game);
    }


    public void RetryButtonCallback()
    {
        GameManager.instance.Retry();
    }


    public void NextButtonCallback()
    {
        GameManager.instance.NextLevel();
    }
}
