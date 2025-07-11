using UnityEngine;

public interface IStartUpManagers
{
    public ManagerStatus Status { get; }
    public void StartUp() { }
}
