using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class GameManager : MonoBehaviour
{
    public int beginIndex;
    public int settingsIndex;

    public void BeginGame()
    {
        SceneManager.LoadScene(beginIndex);
    }

    public void GoToSettings()
    {
        SceneManager.LoadScene(settingsIndex);
    }

    public void QuitGame()
    {
        Debug.Log("Quit Successfully");
        Application.Quit();
    }
    
}
