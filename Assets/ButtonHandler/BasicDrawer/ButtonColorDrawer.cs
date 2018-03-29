using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Cycle
{
    public class ButtonColorDrawer : IButtonDrawer
    {
        public Image button;
        public UnityEngine.Color pressed = UnityEngine.Color.white, highlight = UnityEngine.Color.white, normall = UnityEngine.Color.white, disable = UnityEngine.Color.white;

        protected override void SetState(ButtonColorEnum state)
        {
            switch (state)
            {
                case ButtonColorEnum.HIGHT_LIGHTED:
                    button.color = highlight;
                    break;
                case ButtonColorEnum.PRESSED:
                    button.color = pressed;
                    break;
                case ButtonColorEnum.NORMALL:
                    button.color = normall;
                    break;
                case ButtonColorEnum.DISABLE:
                    button.color = disable;
                    break;
                default:
                    break;
            }
        }
    }
}