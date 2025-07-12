using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIScoreText : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;

    private void Start()
    {
        scoreText.text = $"Score: {Managers.DataController.Score.ToString()}";

        Managers.DataController.ScoreChanged += UpdateScoreText;
    }

    private void OnDestroy()
    {
        if (Managers.DataController != null)
        {
            Managers.DataController.ScoreChanged -= UpdateScoreText;
        }
    }

    private void UpdateScoreText()
    {
        scoreText.text = $"Score: {Managers.DataController.Score.ToString()}";
    }
}
