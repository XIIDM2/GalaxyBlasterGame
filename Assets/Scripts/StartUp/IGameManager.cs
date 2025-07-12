using UnityEngine;

public interface IGameManager
{
    public ManagerStatus Status { get; }
    public void StartUp() { }
}
