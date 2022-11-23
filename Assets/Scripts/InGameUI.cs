using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameUI : MonoBehaviour
{
    [SerializeField] private GameObject _pauseScreen;
    [SerializeField] private GameObject _gameOverScreen;
    [SerializeField] private GameObject _winScreen;
    [SerializeField] private StatsInfoUI _statsInfoScreen;

    private void Update()
    {
        Pause();
    }

    public void Restart()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }

    public void MenuLoad()
    {
        string menuName = "Menu";
        SceneManager.LoadSceneAsync(menuName);
    }

    public void Continue()
    {
        _statsInfoScreen.SwitchStateOfStatsUI();
        Time.timeScale = 1;
    }

    private void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _statsInfoScreen.SwitchStateOfStatsUI();
            Time.timeScale = 0;
        }
    }
}
