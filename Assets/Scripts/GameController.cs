using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class GameController : MonoBehaviour
{
    public UnityEvent OnScoreChange;
    public int Score { get; private set; }
    public void AddScore(int amount)
    {
        Score += amount;
        OnScoreChange.Invoke();
    }
}
