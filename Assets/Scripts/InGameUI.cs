using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameUI : MonoBehaviour
{
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
        Time.timeScale = 1;
    }
    
    
}
