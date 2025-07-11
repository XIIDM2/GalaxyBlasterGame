using UnityEngine;
using UnityEngine.UI;

public class UIStartUpSlider : MonoBehaviour
{
    [SerializeField] private Slider startUpSlider;

    private void Start()
    {
        Managers.ManagerStarted += OnManagerStarted;
    }

    private void OnDestroy()
    {
        Managers.ManagerStarted -= OnManagerStarted;
    }

    private void OnManagerStarted(int startedManagers, int countManagers)
    {
        startUpSlider.value = (float)startedManagers / countManagers;
    }
}
