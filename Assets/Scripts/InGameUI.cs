using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameUI : MonoBehaviour
{
    [SerializeField] private GameObject _pauseScreen;
    [SerializeField] private GameObject _gameOverScreen;
    [SerializeField] private GameObject _winScreen;
    [SerializeField] private StatsInfoUI _statsInfoScreen;
    [SerializeField] private Finish _finish;
    [SerializeField] private Player _player;
    
    private void Update()
    {
        GameOver();
        Win();
        Pause();
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }

    public void MenuLoad()
    {
        string menuName = "MainMenu";
        SceneManager.LoadSceneAsync(menuName);
        Time.timeScale = 1;
    }

    public void Continue()
    {
        _statsInfoScreen.SwitchStateOfStatsUI();
        _pauseScreen.SetActive(false);
        Time.timeScale = 1;
    }

    private void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !_finish.IsFinished)
        {
            _pauseScreen.SetActive(!_pauseScreen.activeSelf);
            _statsInfoScreen.SwitchStateOfStatsUI();
            Time.timeScale = 0;
        }
    }

    private void Win()
    {
        if (_finish.IsFinished)
        {
            _winScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }

    private void GameOver()
    {
        if (_player.IsDead)
        {
            _gameOverScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
