using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIScoreText : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;

    private void Start()
    {
        scoreText.text = $"Score: {ScenesManager.Instance.Score.ToString()}";

        ScenesManager.Instance.ScoreChanged += UpdateScoreText;
    }

    private void OnDestroy()
    {
        if (ScenesManager.Instance != null)
        {
            ScenesManager.Instance.ScoreChanged -= UpdateScoreText;
        }
    }

    private void UpdateScoreText()
    {
        scoreText.text = $"Score: {ScenesManager.Instance.Score.ToString()}";
    }
}
