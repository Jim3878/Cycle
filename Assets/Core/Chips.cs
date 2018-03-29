using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Cycle
{
    public class Chips
    {
        private Dictionary<int, IPlatController> platCtrlList;
        private bool _isInitialize;
        private bool isInitialize
        {
            get
            {
                return _isInitialize;
            }
        }

        public Chips()
        {
            platCtrlList = new Dictionary<int, IPlatController>();
            _isInitialize = false;
        }

        public Chips(params IPlatController[] platCtrl)
        {
            _isInitialize = false;
            for (int i = 0; i < platCtrl.Length; i++)
            {
                this.platCtrlList.Add(platCtrl[i].ID, platCtrl[i]);
            }
        }

        public void Initialize()
        {
            InitializePlat();
        }

        private void InitializePlat()
        {
            foreach (var plat in platCtrlList)
            {
                plat.Value.Initialize();
            }
        }

        public void RegistPlat(IPlatController platCtr)
        {
            if (this.platCtrlList.ContainsKey(platCtr.ID))
            {
                this.platCtrlList.Remove(platCtr.ID);
            }
            this.platCtrlList.Add(platCtr.ID, platCtr);

            if (_isInitialize)
            {
                platCtr.Initialize();
            }
        }

        public IPlatController GetPlat(int ID)
        {
            if (!platCtrlList.ContainsKey(ID))
            {
                throw new ArgumentOutOfRangeException("[Chips]找不到指定ID的PlatController\nID = " + ID);
            }
            return platCtrlList[ID];
        }
    }
}