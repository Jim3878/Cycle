using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Cycle
{
    public class ClickButton : EventTrigger
    {
        public IButtonController ctrl;
        private bool isEnter;
        private void Start()
        {
            isEnter = false;
            ctrl = GetComponent<IButtonController>();
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            ctrl.SetState(ButtonColorEnum.PRESSED);
        }

        public override void OnPointerEnter(PointerEventData eventData)
        {
            isEnter = true;
            ctrl.SetState(ButtonColorEnum.HIGHT_LIGHTED);
        }

        public override void OnPointerExit(PointerEventData eventData)
        {
            isEnter = false;
            ctrl.SetState(ButtonColorEnum.NORMALL);
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            if (isEnter)
                ctrl.Trigger();
            ctrl.SetState(ButtonColorEnum.NORMALL);
        }
    }

}