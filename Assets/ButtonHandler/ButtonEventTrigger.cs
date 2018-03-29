using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cycle
{
    [RequireComponent(typeof(CycleEventTrigger))]
    public class ButtonEventTrigger : IButtonHandler
    {
        public CycleEventTrigger eventTrigger;
        public float clickTime = 0;

        private IButtonController controller;

        public override void Initialize(IButtonController controller)
        {
            this.controller = controller;
            eventTrigger.onMouseDown += OnPointerDown;
            eventTrigger.onMouseEnter +=OnPointerEnter;
            eventTrigger.onMouseExit += OnPointerExit;
            eventTrigger.onMouseUp += OnPointerUp;
            eventTrigger.onMouseClick += OnPointerDash;
        }

        private void OnPointerEnter()
        {
            controller.SetState(ButtonColorEnum.HIGHT_LIGHTED);
        }

        private void OnPointerExit()
        {
            if (!eventTrigger.isPointerDown)
                controller.SetState(ButtonColorEnum.NORMALL);
        }

        private void OnPointerDown()
        {
            controller.SetState(ButtonColorEnum.PRESSED);
        }

        private void OnPointerUp()
        {
            controller.Trigger();
            controller.SetState(ButtonColorEnum.NORMALL);
        }
        private void OnPointerDash(float time)
        {
            this.clickTime = time;
        }
    }
}