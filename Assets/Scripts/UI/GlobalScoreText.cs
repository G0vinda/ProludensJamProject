using LitMotion;
using LitMotion.Extensions;
using UnityEngine;
using UnityEngine.UI;

public class GlobalScoreText : MonoBehaviour
{
    [SerializeField] private Text counterText;
    [SerializeField] private float animationDuration;
    [SerializeField] private Vector3 targetScale;

    private Vector3 originalScale;
    private MotionHandle animationHandle;

    private void Awake()
    {
        originalScale = transform.localScale;
    }

    [ContextMenu("Set Counter Test")]
    public void SetCounterTest()
    {
        SetCounter(19);
    }
    public void SetCounter(int points)
    {
        counterText.text = points.ToString();
        
        AnimateText();
    }

    private void AnimateText()
    {
        if (animationHandle.IsActive())
        {
            animationHandle.Cancel();
            counterText.transform.localScale = originalScale;
        }

        animationHandle = LMotion.Create(originalScale, targetScale, animationDuration / 2f)
            .WithEase(Ease.OutQuad)
            .WithLoops(2, LoopType.Yoyo)
            .BindToLocalScale(counterText.transform);
    }

    private void OnDestroy()
    {
        if (animationHandle.IsActive())
        {
            animationHandle.Cancel();
        }
    }
}