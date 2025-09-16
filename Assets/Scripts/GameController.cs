using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    public UnityEvent OnScoreChange;
    public UnityEvent Win;
    public UnityEvent Lose;
    public UnityEvent StudentCorrupted;
    public int Score { get; private set; }
    public int corruptionScore { get; private set; }
    private StudentSpawner studentSpawner;
    public int totalStudents;
    private void Awake()
    {
        studentSpawner = FindObjectOfType<StudentSpawner>();
        totalStudents = studentSpawner.spawnCount;
    }
    public void AddCorruptScore()
    {
        corruptionScore++;
        totalStudents--;
        OnScoreChange.Invoke();
        StudentCorrupted.Invoke();
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
            if (corruptionScore <= 5)
                StartCoroutine(LoseLevel());
            else
                StartCoroutine(WinLevel());
        }
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene(0); 
    }

    public void LoadLevel(int levelNo)
    {
        SceneManager.LoadScene(levelNo);
    }

    IEnumerator WinLevel()
    {
        yield return new WaitForSeconds(2);
        Win.Invoke();
    }
    IEnumerator LoseLevel()
    {
        yield return new WaitForSeconds(2);
        Lose.Invoke();
    }
}
    