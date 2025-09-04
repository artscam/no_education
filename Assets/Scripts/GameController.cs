using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class GameController : MonoBehaviour
{
    public UnityEvent OnScoreChange;
    
    public int Score { get; private set; }
    public int corruptionScore { get; private set; }


    public void AddCorruptScore()
    {
        corruptionScore++;
        OnScoreChange.Invoke();
        Debug.Log($"corruption score is : {corruptionScore}");
    }

    public void AddScore()
    {
        Score++;
        OnScoreChange.Invoke();
    }
}
