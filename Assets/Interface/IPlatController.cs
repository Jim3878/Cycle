using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cycle
{
    #region VARIABLE
    public enum PlatState
    {
        INITIALIZE,
        LOCK,
        UNLOCK,
        SHOW,
        HIDE
    }

    public enum ButtonChange
    {
        REGIST,
        REMOVE
    }

    public enum ShowHideEnum
    {
        Show,
        Hide,
    }

    public class ShowHideArgs : EventArgs
    {
        public ShowHideEnum action;
        public ShowHideArgs(ShowHideEnum action)
        {
            this.action = action;
        }
    }

    public class PlatStateArgs : EventArgs
    {
        public PlatState state;
        public PlatStateArgs(PlatState state)
        {
            this.state = state;
        }
    }

    public class ButtonChangeArgs : EventArgs
    {
        public IButtonInstance button;
        public ButtonChange change;
        public ButtonChangeArgs(IButtonInstance button, ButtonChange change)
        {
            this.button = button;
            this.change = change;
        }
    }
    #endregion

    public abstract class PlatInstance : MonoBehaviour
    {
        public abstract int ID { get; }
        public abstract void Initialize();
    }

    public interface IPlatController
    {
        bool isLock { get; }
        bool isShow { get; }
        bool isInitialize { get; }
        int ID { get; }
        event EventHandler<ButtonChangeArgs> onButtonChange;
        event EventHandler<ShowHideArgs> onShowHide;
        event EventHandler<SwitchLockArgs> onSwitchLock;
        event EventHandler onInitialize;
        void SetLock(bool value);
        void Initialize();
        bool ContainsButton(int ID);
        IButtonInstance GetButton(int ID);
        IButtonInstance[] GetAllButton();
        void RegistButton(IButtonInstance button);
        void RemoveButton(int ID);
        void Show(bool isComplete = false);
        void Hide(bool isComplete = false);
    }
}