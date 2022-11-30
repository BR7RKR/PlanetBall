using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    [SerializeField] private AudioClip _pressedButtonSound;
    [SerializeField] private GameObject _controlsBackdrop;
    public bool IsShowingControls { get; private set; }

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void Play()
    {
        _audioSource.PlayOneShot(_pressedButtonSound);
        
        var levelName = "LevelOne";
        SceneManager.LoadSceneAsync(levelName);
    }

    public void Quit()
    {
        _audioSource.PlayOneShot(_pressedButtonSound);
        
        Application.Quit();
        Debug.Log("Quit");
    }

    public void Controls()
    {
        _audioSource.PlayOneShot(_pressedButtonSound);
        
        IsShowingControls = !IsShowingControls;
        _controlsBackdrop.SetActive(IsShowingControls);
    }
}
