using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cycle
{
    public abstract class IButtonDrawer : IButtonHandler
    {
        public override void Initialize(IButtonController controller)
        {
            controller.onColorChange += OnColorChange;
        }


        private void OnColorChange(object sneder, ButtonColorArgs e)
        {
            SetState(e.color);
        }

        protected abstract void SetState(ButtonColorEnum state);

    }
}