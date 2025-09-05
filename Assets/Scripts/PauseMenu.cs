using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public UnityEvent onPaused;
    public UnityEvent onUnpaused;
    public static bool isPaused;


    private void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            if (!isPaused)
                PauseGame();
            else
                ResumeGame();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        isPaused = true;
        onPaused.Invoke();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        isPaused = false;
        onUnpaused.Invoke();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadLevel(int levelNo)
    {
        ResumeGame();
        SceneManager.LoadScene(levelNo);
    }


}
