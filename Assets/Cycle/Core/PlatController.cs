using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cycle
{
    public class PlatController : PlatInstance, IPlatController
    {
        [HideInInspector]
        public bool isDebug = true;
        private string debugName
        {
            get
            {
                return string.Format("[Plat Controller :{0}]", ID);
            }
        }
        private bool _isLock;
        public bool isLock
        {
            get
            {
                return _isLock;
            }
        }
        private bool _isInitialize = false;
        public bool isInitialize
        {
            get
            {
                return _isInitialize;
            }
        }
        private bool _isShow;
        public bool isShow
        {
            get
            {
                return _isShow;
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
        public List<IButtonInstance> buttonList;
        [SerializeField]
        private List<IPlatHandler> _platHandlerList;
        public event EventHandler<ButtonChangeArgs> onButtonChange;
        public event EventHandler<ShowHideArgs> onShowHide;
        public event EventHandler<SwitchLockArgs> onSwitchLock;
        public event EventHandler onInitialize;
        

        public IButtonInstance GetButton(int ID)
        {
            if (!ContainsButton(ID) && isDebug)
            {
                Debug.Log(string.Format("{0}找不到指定按鈕[{1}]", debugName, ID));
                return null;
            }
            return buttonList.Find((x) => x.ID == ID);
        }

        public override void Initialize()
        {
            if (isInitialize)
            {
                if (isDebug)
                {
                    Debug.Log(string.Format("{0}重覆呼叫Initialize()", debugName));
                }
                return;
            }
            _isInitialize = true;
            InitializeAllButton();
            InitializeHandler();
            _isShow = true;
            this.SetLock(false);
            this.Hide(true);
            this.SetLock(true);
            if (onInitialize != null)
            {
                onInitialize(this, new EventArgs());
            }
            if (isDebug)
            {
                Debug.Log(string.Format("{0}Initialize done.", debugName));
            }
        }

        private void InitializeHandler()
        {
            foreach (var handler in this._platHandlerList)
            {
                handler.Initialize(this);
            }
        }

        public bool ContainsButton(int ID)
        {
            return buttonList.Find((x) => x.ID == ID) == null;
        }

        public void RegistButton(IButtonInstance button)
        {
            if (this.ContainsButton(button.ID))
            {
                this.RemoveButton(button.ID);
                if (isDebug)
                {
                    Debug.Log(string.Format("{0}將已註冊之按鈕[{1}]覆蓋", debugName, button.ID));
                }
            }
            this.buttonList.Add(button);
            button.Initialize(this);
            if (onButtonChange != null)
                onButtonChange(this, new ButtonChangeArgs(button, ButtonChange.REGIST));
        }

        private void InitializeAllButton()
        {
            foreach (var btn in buttonList)
            {
                InitializeButton(btn);
            }
        }

        private void InitializeButton(IButtonInstance button)
        {
            if (!button.isInitialize)
            {
                button.Initialize(this);
            }
        }

        public void RemoveButton(int ID)
        {
            if (!this.ContainsButton(ID) && isDebug)
            {
                Debug.Log(string.Format("{0}企圖移除不存在的按鈕 {1}", debugName, ID));
                return;
            }
            var btn = GetButton(ID);
            buttonList.RemoveAll((x) => x.ID == ID);

            if (onButtonChange != null)
                onButtonChange(this, new ButtonChangeArgs(btn, ButtonChange.REGIST));
        }

        public void SetLock(bool value)
        {
            if (this.isLock == value)
            {
                return;
            }
            _isLock = value;
            if (this.onSwitchLock != null)
            {
                this.onSwitchLock(this, new SwitchLockArgs(value ? LockEnum.LOCK : LockEnum.UNLOCK));
            }
        }

        public void Hide(bool isComplete = false)
        {
            if (!_isShow)
            {
                return;
            }
            _isShow = false;
            if (this.onShowHide != null)
            {
                this.onShowHide(this, new ShowHideArgs(ShowHideEnum.Hide, isComplete));
            }
        }

        public void Show(bool isComplete = false)
        {
            if (_isShow)
            {
                return;
            }
            _isShow = true;
            if (this.onShowHide != null)
            {
                this.onShowHide(this, new ShowHideArgs(ShowHideEnum.Show, isComplete));
            }
        }

        public IButtonInstance[] GetAllButton()
        {
            buttonList.RemoveAll((x) => x == null);
            return this.buttonList.ToArray();
        }
    }
}