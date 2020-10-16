using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ButtonControl : MonoBehaviour
{
    [SerializeField] private Button playButton;

    void Start()
    {
        playButton.onClick.AddListener(PressAnimate);
    }
    void PressAnimate()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(playButton.transform.DOShakeRotation(
            2.0f, new Vector3(20, 0, 30), 100, 40));
        sequence.Join(playButton.transform.DOShakePosition(
            2.0f, new Vector3(20, 20), 100, 40));
    }
}
