using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void LoadGame()
    {
        SceneManager.LoadScene(1); // load level 1
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
