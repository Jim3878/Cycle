using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Cycle
{
    public class CycleEventTrigger : EventTrigger
    {

        public delegate void FloatPass(float value);
        public delegate void BoolPass(bool value);
        public delegate void VoidPass();

        public event VoidPass onMouseDown;
        public event VoidPass onMouseUp;
        public event VoidPass onMouseEnter;
        public event VoidPass onMouseExit;
        public event FloatPass onMouseClick;
        public bool isPointerDown=false;
        public bool isPointerEnter=false;

        private float lastPointDownTime;


        public override void OnPointerClick(PointerEventData eventData)
        {
            if (onMouseClick != null)
            {
                onMouseClick(Time.time - lastPointDownTime);
            }
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            this.lastPointDownTime = Time.time;
            isPointerDown = true;
            if (onMouseDown != null)
            {
                onMouseDown();
            }
        }

        public override void OnPointerEnter(PointerEventData eventData)
        {
            isPointerEnter = true;
            if (onMouseEnter != null)
            {
                onMouseEnter();
            }
        }

        public override void OnPointerExit(PointerEventData eventData)
        {
            isPointerEnter = false;
            if (onMouseExit != null)
            {
                onMouseExit();
            }
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            isPointerDown = false;
            if (onMouseUp != null)
            {
                onMouseUp();
            }
        }
    }
}