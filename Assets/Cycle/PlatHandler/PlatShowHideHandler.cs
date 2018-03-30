using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Cycle
{

    public class PlatShowHideHandler : IPlatHandler
    {
        public enum TweenEnum
        {
            ZOOM,
            FLIP,
        }
        public TweenEnum tweenType;
        IPlatTween tween;
        public override void Initialize(IPlatController controller)
        {
            switch (tweenType)
            {
                case TweenEnum.ZOOM:
                    tween = new PlatZoom();
                    break;
                case TweenEnum.FLIP:
                    tween = new PlatFlip();
                    break;
                default:
                    break;
            }
            tween.SetProperty(transform);
            controller.onShowHide += OnShowHide;
        }

        public void OnShowHide(object o, ShowHideArgs e)
        {
            if (e.action == ShowHideEnum.Hide)
            {
                tween.Hide(e.isComplete);
            }
            else
            {
                tween.Show(e.isComplete);
            }
        }
    }
}