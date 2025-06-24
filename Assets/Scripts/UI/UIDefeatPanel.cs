using UnityEngine;
using DG.Tweening;

public class UIDefeatPanel : MonoBehaviour
{
    [SerializeField] private GameObject defeatPanel;

    private CanvasGroup canvasGroup;

    private void Start()
    {
        canvasGroup = GetComponentInChildren<CanvasGroup>();

        defeatPanel.SetActive(false);

        SceneController.Instance.Defeat += ShowDefeatPanel;
    }

    private void OnDestroy()
    {
        if (SceneController.Instance != null)
        {
            SceneController.Instance.Defeat -= ShowDefeatPanel;
        }

        if (canvasGroup != null)
        {
            canvasGroup.DOKill();
        }

        if (defeatPanel != null)
        {
            defeatPanel.transform.DOKill();
        }
    }

    private void ShowDefeatPanel()
    {
        defeatPanel.SetActive(true);

        canvasGroup.alpha = 0;
        defeatPanel.transform.localScale = Vector3.zero;

        SceneController.Instance.SlowTime();

        canvasGroup.DOFade(1, 1).SetEase(Ease.OutQuad);
        defeatPanel.transform.DOScale(Vector3.one, 1).SetEase(Ease.OutBack);
        
    }

}
