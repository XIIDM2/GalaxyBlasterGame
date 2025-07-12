using UnityEngine;
using UnityEngine.Events;

public class DataManager : MonoBehaviour, IGameManager
{
    public ManagerStatus Status { get; private set; }

    public UnityAction ScoreChanged;

    private int score;
    public int Score
    {
        get
        {
            return score;
        }
        private set
        {
            score = value;
            ScoreChanged?.Invoke();
        }
    }
    
    public void StartUp()
    {
        Status = ManagerStatus.Initializing;


        Status = ManagerStatus.Started;
    }

    public void SaveGame()
    {
        PlayerPrefs.SetInt("PlayerScore", Score);
    }

    public void LoadGame()
    {
        Score = PlayerPrefs.GetInt("PlayerScore", 0);
    }

    public void ResetData()
    {
        Score = 0;
    }

    public void AddScore(int value)
    {
        Score += value;
    }
}
