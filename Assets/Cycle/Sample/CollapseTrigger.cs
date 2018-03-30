using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cycle;
using System;

public class CollapseTrigger : IButtonHandler
{
    public override void Initialize(IButtonController controller)
    {
        controller.onTrigger += OnTrigger;
    }

    public void OnTrigger(object o ,EventArgs e)
    {
        ((o as ButtonController).plat as PlatController).Hide();
    }
}
