using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    [SerializeField] private GameObject _controlsBackdrop;
    public bool IsShowingControls { get; private set; }

    public void Play()
    {
        var levelName = "LevelOne";
        SceneManager.LoadSceneAsync(levelName);
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void Controls()
    {
        IsShowingControls = !IsShowingControls;
        _controlsBackdrop.SetActive(IsShowingControls);
    }
}
