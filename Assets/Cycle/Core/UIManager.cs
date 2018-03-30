using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Cycle
{
    public class UIManager
    {
        private bool _isDebug = true;
        private string _debugName = "[UIManager]";
        public static UIManager _instance;
        public static UIManager instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UIManager();
                }
                return _instance;
            }
        }

        private Dictionary<int, PlatInstance> platList = new Dictionary<int, PlatInstance>();

        public void RegistPlat(PlatInstance plat)
        {
            if (platList.ContainsKey(plat.ID))
            {
                platList.Remove(plat.ID);
                if (_isDebug)
                {
                    Debug.Log(string.Format("{0}移除重覆的介面[{1}]", _debugName, plat.ID));
                }
            }
            plat.Initialize();
            this.platList.Add(plat.ID, plat);
        }

        public void RemovePlat(int ID)
        {
            if (!platList.ContainsKey(ID) && _isDebug)
            {
                Debug.Log(string.Format("{0}企圖移除不存在的介面[{1}]", _debugName, ID));
                return;
            }
            this.platList.Remove(ID);
        }

        public PlatInstance GetPlat(int ID)
        {
            if (!platList.ContainsKey(ID))
            {
                throw new ArgumentException(string.Format("{0}欲取得的介面[{1}]不存在", _debugName, ID));
            }
            return platList[ID];
        }

        public PlatInstance[] GetAllPlat()
        {
            List<PlatInstance> result=new List<PlatInstance>();
            foreach(var meta in platList)
            {
                result.Add(meta.Value);
            }
            return result.ToArray();
        }

    }
}