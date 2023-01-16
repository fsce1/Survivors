using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMgr : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void LoadScene1()
    {
        SceneManager.LoadScene("Scene1");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
