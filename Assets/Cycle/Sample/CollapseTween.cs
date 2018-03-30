using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cycle;
using DG.Tweening;
using System;
using UnityEngine.UI;

public class CollapseTween : IPlatHandler
{
    public Transform button;
    private float _y;

    public override void Initialize(IPlatController controller)
    {
        controller.onShowHide += OnShowHide;
        _y = button.transform.position.y;
    }

    private void OnShowHide(object o, ShowHideArgs e)
    {
        button.DOKill();
        transform.DOKill();
        if (e.action == ShowHideEnum.Show)
        {
            Show(e.isComplete);
        }
        else
        {
            Hide(e.isComplete);
        }
    }

    private void Show(bool isComplete)
    {
        gameObject.SetActive(true);
        button.GetComponent<Image>().raycastTarget = false;
        var t1 = transform.DOLocalMoveY(130, 0.5f);
        var t2 = button.GetComponent<RectTransform>().DOMoveY(_y - 160, 0.5f);
        if (isComplete)
        {
            t1.Complete();
            t2.Complete();
        }
    }

    private void Hide(bool isComplete)
    {
        button.GetComponent<Image>().raycastTarget = true;
        var t1 = transform.DOLocalMoveY(290, 0.5f).OnComplete(() => gameObject.SetActive(false));
        var t2 = button.GetComponent<RectTransform>().DOMoveY(_y, 0.5f);
        if (isComplete)
        {
            t1.Complete();
            t2.Complete();
        }
    }



}
