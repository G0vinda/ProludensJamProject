using LitMotion;
using LitMotion.Extensions;
using UnityEngine;

public class StormAnimation : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _bgRenderer;
    [SerializeField] private SpriteRenderer spriral1;
    [SerializeField] private SpriteRenderer spriral2;
    [SerializeField] private SpriteRenderer spriral3;
    
    void Start()
    {
        var bgColor = _bgRenderer.color;
        var spiral1Color = spriral1.color;
        var spiral2Color = spriral2.color;
        var spiral3Color = spriral3.color;
        
        LSequence.Create()
            .Append(LMotion.Create(0f, -6f, 1.5f).WithEase(Ease.OutSine).Bind(r => transform.Rotate(0f, 0f, r)))
            .Join(LMotion.Create(1.7867f, 2.3f, 1.3f).WithEase(Ease.OutSine).BindToLocalScaleXYZ(transform))
            .Join(LMotion.Create(1f, 0f, 1f).WithDelay(0.5f).WithEase(Ease.OutSine).Bind(a =>
        {
            bgColor.a = a;
            _bgRenderer.color = bgColor;
            spiral1Color.a = a;
            spiral2Color.a = a;
            spiral3Color.a = a;
            spriral1.color = spiral1Color;
            spriral2.color = spiral2Color;
            spriral3.color = spiral3Color;
        })).Run();
    }
}

