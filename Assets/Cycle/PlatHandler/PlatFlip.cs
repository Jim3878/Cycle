using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlatFlip : IPlatTween
{

    public override void Hide(bool isComplete)
    {
        transform.DOKill();
        var t=transform.DOMoveY(-300, 0.5f).OnComplete(() => transform.gameObject.SetActive(false)); ;
        if (isComplete)
            t.Complete();
    }

    public override void Show(bool isComplete)
    {
        transform.DOKill();
        transform.gameObject.SetActive(true);
        var t = transform.DOMoveY(300, 0.5f);
        if (isComplete)
            t.Complete();
    }
}
