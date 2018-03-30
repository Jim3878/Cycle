using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cycle
{


    public class ButtonController : IButtonInstance, IButtonController
    {
        [HideInInspector]
        public bool isDebug = true;
        private bool _isLock;
        public bool isLock
        {
            get
            {
                return _isLock;
            }
        }
        [SerializeField]
        private int _ID;
        public override int ID
        {
            get
            {
                return _ID;
            }
        }
        private PlatInstance _plat;
        public List<IButtonHandler> handlers;

        public PlatInstance plat
        {
            get
            {
                return _plat;
            }
        }
        private ButtonColorEnum _currentState;
        public ButtonColorEnum currentState
        {
            get
            {
                return _currentState;
            }
        }
        private bool _isInitialize = false;
        public override bool isInitialize
        {
            get
            {
                return _isInitialize;
            }
        }
        public event EventHandler onTrigger;
        public event EventHandler<ButtonColorArgs> onColorChange;
        public event EventHandler<SwitchLockArgs> onSwitchLock;
        public event EventHandler onInitilize;

        public override void Initialize(PlatInstance plat)
        {
            if (!_isInitialize)
            {
                _isInitialize = true;
                this._plat = plat;
                InitilizeButtonComponent();
                this.SetState(ButtonColorEnum.NORMALL);
                this._isLock = true;
                if (onInitilize != null)
                {
                    onInitilize(this,new EventArgs());
                }
                if (isDebug)
                    Debug.Log(string.Format("[Button: {0}]Initialize done.", ID));
            }
            else
            {
                if (isDebug)
                    Debug.Log(string.Format("[Button: {0}]I already initialize.", ID));
            }
        }

        private void InitilizeButtonComponent()
        {
            foreach (var handler in this.handlers)
            {
                AddButtonComponent(handler);
            }
        }

        public void AddButtonComponent(IButtonHandler handler)
        {
            handler.Initialize(this);
        }

        public void SetState(ButtonColorEnum state)
        {
            if (!isLock && state != currentState)
            {
                _currentState = state;
                if (this.onColorChange != null)
                {
                    onColorChange(this, new ButtonColorArgs(state));
                }
            }
        }

        public void SetLock(bool value)
        {
            if (this._isLock != value)
            {
                this._isLock = value;
                if (onSwitchLock != null)
                {
                    onSwitchLock(this, new SwitchLockArgs(this.isLock ? LockEnum.LOCK : LockEnum.UNLOCK));
                }
            }
        }

        public void Trigger()
        {
            if (isLock && isDebug)
            {
                Debug.Log(string.Format("[Button: {0}] Is Lock.", ID));
                return;
            }
            if (this.onTrigger != null)
            {
                onTrigger(this, new EventArgs());
            }
        }

    }
}