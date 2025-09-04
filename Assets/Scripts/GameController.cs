using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    public UnityEvent OnScoreChange;
    public UnityEvent onPaused;
    public UnityEvent onUnpaused;
    public int Score { get; private set; }
    public int corruptionScore { get; private set; }
    private StudentSpawner studentSpawner;
    private int totalStudents;
    private void Awake()
    {
        studentSpawner = FindObjectOfType<StudentSpawner>();
        totalStudents = studentSpawner.spawnCount;
        Debug.Log($"spawning {totalStudents} students");
    }
    public void AddCorruptScore()
    {
        corruptionScore++;
        totalStudents--;
        OnScoreChange.Invoke();
    }

    public void AddScore()
    {
        Score++;
        totalStudents--;
        OnScoreChange.Invoke();
    }

    public void EndLevel()
    {
        // once all the students are gone, end the level    
        if (totalStudents == 0)
        {
            LoadMenu();
        }
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene(0); 
    }

    private void Update()
    {
        
        if (Input.GetKeyDown("escape"))
        {
            PauseGame();
        }
    }
    public static bool isPaused = false;
    public void PauseGame()
    {
        //toggles between paused and active (0,1)
        Time.timeScale = 1 - Time.timeScale;
        isPaused = !isPaused;
        if (isPaused)
        {
            onPaused.Invoke();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            onUnpaused.Invoke();
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        Debug.Log(Cursor.lockState);
    }
}
    