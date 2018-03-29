using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cycle
{
    public abstract class IButtonTrigger :  IButtonHandler
    {
        public override void Initialize(IButtonController controller)
        {
            controller.onTrigger += OnTrigger;
        }

        private void OnTrigger(object sender, EventArgs e)
        {
            ButtonController ctrl = sender as ButtonController;
            Trigger(ctrl.plat.ID, ctrl.ID);
        }

        protected abstract void Trigger(int platID, int BtnID);

    }
}