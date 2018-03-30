using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cycle
{
    public static class PlatControllerUtility
    {
        public static void SetAllButtonLock(this PlatController ctrl,bool value)
        {
            foreach(var btn in ctrl.GetAllButton())
            {
                (btn as IButtonController).SetLock(value);
            }
        }

        public static void ShowAndUnlockAllButton(this PlatController ctrl,bool isComplete=false)
        {
            if (!ctrl.isShow)
            {
                ctrl.Show(isComplete);
                ctrl.SetAllButtonLock(false);
            }
        }

        public static void HideAndlockAllButton(this PlatController ctrl, bool isComplete = false)
        {
            if (ctrl.isShow)
            {
                ctrl.Hide(isComplete);
                ctrl.SetAllButtonLock(true);
            }
        }
    }
}