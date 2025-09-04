using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    private TMP_Text _scoreText;
    private string bufferText;
    private void Awake()
    {
        _scoreText = GetComponent<TMP_Text>();
        bufferText = _scoreText.text;        
    }

    public void UpdateScore(GameController gameController)
    {
        _scoreText.text = $"{bufferText} {gameController.Score}";
    }
    public void UpdateCorruptScore(GameController gameController)
    {
        _scoreText.text = $"{bufferText} {gameController.corruptionScore}";
    }
}
