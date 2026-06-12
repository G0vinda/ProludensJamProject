using System;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class VisibilityChanger : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ToDisabled()
    {
        var color = _spriteRenderer.color;
        color.a = 0.5f;
        _spriteRenderer.color = color;
    }
}