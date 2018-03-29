using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


namespace Cycle
{

    public enum ButtonColorEnum
    {
        HIGHT_LIGHTED,
        PRESSED,
        NORMALL,
        DISABLE,
    }

    public enum LockEnum
    {
        LOCK,
        UNLOCK
    }

    public class SwitchLockArgs : EventArgs
    {
        public LockEnum switchTo;
        public SwitchLockArgs(LockEnum switchTo)
        {
            this.switchTo = switchTo;
        }
    }

    public class ButtonColorArgs : EventArgs
    {
        public ButtonColorEnum color;
        public ButtonColorArgs(ButtonColorEnum color)
        {
            this.color = color;
        }
    }

    public abstract class IButtonInstance : MonoBehaviour
    {
        public abstract int ID { get; }
        public abstract bool isInitialize { get; }
        public abstract void Initialize(PlatInstance plat);
    }

    public interface IButtonController
    {
        event EventHandler<SwitchLockArgs> onSwitchLock;
        event EventHandler onTrigger;
        event EventHandler onInitilize;
        event EventHandler<ButtonColorArgs> onColorChange;
        bool isLock { get; }
        bool isInitialize { get; }
        int ID { get; }
        PlatInstance plat { get; }
        ButtonColorEnum currentState { get; }
        void AddButtonComponent(IButtonHandler handler);
        void Initialize(PlatInstance plat);
        void SetLock(bool value);
        void Trigger();
        void SetState(ButtonColorEnum State);

    }
}