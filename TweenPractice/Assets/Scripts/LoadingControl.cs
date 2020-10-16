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
        StartCoroutine(AnimateBar());
    }

    IEnumerator AnimateBar()
    {
        while (true)
        {
            Sequence sequence = DOTween.Sequence();
            foreach (var bar in bars)
            {
                Debug.Log(bar.name);
                sequence.Append(bar.DOSizeDelta(new Vector2(45, 70), 0.15f));
                yield return new WaitForSeconds(0.1f);
                sequence.Append(bar.DOSizeDelta(new Vector2(45, 45), 0.15f));
            }
            
            yield return new WaitForSeconds(0.5f);
        }

    }
}
