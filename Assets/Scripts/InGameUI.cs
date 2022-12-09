using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class InGameUI : MonoBehaviour
{
    [SerializeField] private AudioSource _cameraAudioSource;
    [SerializeField] private AudioClip _gameOverSound;
    [SerializeField] private AudioClip _pressedButtonSound;
    [SerializeField] private GameObject _pauseScreen;
    [SerializeField] private GameObject _gameOverScreen;
    [SerializeField] private GameObject _winScreen;
    [SerializeField] private StatsInfoUI _statsInfoScreen;
    [SerializeField] private Finish _finish;
    [SerializeField] private Player _player;
    
    private AudioSource _audioSource;
    private bool _isWon;
    private bool _isGameOver;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        GameOver();
        Win();
        Pause();
    }

    public void Restart()
    {
        _audioSource.PlayOneShot(_pressedButtonSound);
        
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }

    public void MenuLoad()
    {
        _audioSource.PlayOneShot(_pressedButtonSound);
        
        string menuName = "MainMenu";
        SceneManager.LoadSceneAsync(menuName);
        Time.timeScale = 1;
    }

    public void Continue()
    {
        _audioSource.PlayOneShot(_pressedButtonSound);
        
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
        if (_finish.IsFinished && !_isWon)
        {
            _cameraAudioSource.Stop();
            _winScreen.SetActive(true);
            Time.timeScale = 0;
            _isWon = !_isWon;
        }
    }

    private void GameOver()
    {
        if (_player.IsDead && !_isGameOver)
        {
            _cameraAudioSource.Stop();
            _audioSource.PlayOneShot(_gameOverSound);
            
            _gameOverScreen.SetActive(true);
            Time.timeScale = 0;
            _isGameOver = !_isGameOver;
        }
    }
}
