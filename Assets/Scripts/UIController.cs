using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    private TMP_Text _scoreText;
    private void Awake()
    {
        _scoreText = GetComponent<TMP_Text>();
        
    }

    public void UpdateScore(GameController gameController)
    {
        Debug.Log("current text: " + _scoreText.text);
        _scoreText.text = $"classmates indoctrinated: {gameController.Score}";
    }
}
