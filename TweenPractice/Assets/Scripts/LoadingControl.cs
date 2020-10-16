using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class LoadingControl : MonoBehaviour
{
    [SerializeField] private RectTransform[] bars;

    private void Start()
    {
        AnimateBar();
    }

    public void AnimateBar()
    {
        Sequence sequence = DOTween.Sequence();
        foreach (var bar in bars)
        {
            sequence.Append(bar.DOSizeDelta(new Vector2(45, 70), 0.15f));
        }
        
        foreach (var bar in bars)
        {
            sequence.Append(bar.DOSizeDelta(new Vector2(45, 45), 0.15f));
        }

        sequence.OnComplete(AnimateBar);
    }
}
