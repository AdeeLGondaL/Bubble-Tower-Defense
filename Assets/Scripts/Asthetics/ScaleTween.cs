using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ScaleTween : MonoBehaviour
{
    [SerializeField] private float startingScale, targetScale;

    [SerializeField] private float duration;

    [SerializeField] private Ease easeType;
    [Tooltip("Set -1 for infinity")]
    [SerializeField] private int numberOfLoops;

    [SerializeField] private LoopType loopType;

    [SerializeField] private float delayInStart;
    // Update is called once per frame
    void Start()
    {
        transform.localScale = Vector3.one * startingScale;
        transform.DOScale(new Vector3(targetScale, targetScale, targetScale), duration).SetEase(easeType)
            .SetLoops(numberOfLoops, loopType).SetDelay(delayInStart).SetUpdate(true);
    }
}
