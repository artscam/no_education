using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text.RegularExpressions;

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
    string pat = @"[\D ]+";
    
    public void UpdateRemaining(GameController gameController)
    {
        Regex r = new Regex(pat, RegexOptions.IgnoreCase);
        string buffer = r.Match(_scoreText.text).Value;
        _scoreText.text = $"{buffer} {gameController.totalStudents}";
    }
}
