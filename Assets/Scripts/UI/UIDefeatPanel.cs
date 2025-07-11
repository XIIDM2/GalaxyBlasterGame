using UnityEngine;
using DG.Tweening;
using TMPro;

public class UIDefeatPanel : MonoBehaviour
{
    [SerializeField] private GameObject defeatPanel;
    [SerializeField] private TMP_Text scoreText;

    private CanvasGroup canvasGroup;

    private void Start()
    {
        canvasGroup = GetComponentInChildren<CanvasGroup>();

        defeatPanel.SetActive(false);

        ScenesManager.Instance.Defeat += ShowDefeatPanel;

    }

    private void OnDestroy()
    {
        if (ScenesManager.Instance != null)
        {
            ScenesManager.Instance.Defeat -= ShowDefeatPanel;
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

        scoreText.text = $"Score: {ScenesManager.Instance.Score.ToString()}";

        canvasGroup.alpha = 0;
        defeatPanel.transform.localScale = Vector3.zero;

        ScenesManager.Instance.SlowTime();

        canvasGroup.DOFade(1, 1).SetEase(Ease.OutQuad);
        defeatPanel.transform.DOScale(Vector3.one, 1).SetEase(Ease.OutBack);
        
    }

}
