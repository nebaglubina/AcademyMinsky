using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class RotatingControl : MonoBehaviour
{
    [SerializeField] private Transform point;
    [SerializeField] private Vector3 rotationVector;

    private void Start()
    {
        Loading();
    }

    public void Loading()
    {
        point.DORotate(rotationVector, 1f,
            RotateMode.FastBeyond360).SetLoops(-1, LoopType.Incremental).SetEase(Ease.Linear);
    }
}