using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIScoreText : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;

    private void Start()
    {
        scoreText.text = $"Score: {SceneController.Instance.Score.ToString()}";

        SceneController.Instance.ScoreChanged += UpdateScoreText;
    }

    private void OnDestroy()
    {
        if (SceneController.Instance != null)
        {
            SceneController.Instance.ScoreChanged -= UpdateScoreText;
        }
    }

    private void UpdateScoreText()
    {
        scoreText.text = $"Score: {SceneController.Instance.Score.ToString()}";
    }
}
