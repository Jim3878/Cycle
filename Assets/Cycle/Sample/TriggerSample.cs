using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cycle;

public class TriggerSample : IButtonTrigger
{
    public List<PlatController> platList;
    protected override void Trigger(int platID, int BtnID)
    {
        foreach (var plat in platList)
        {
            if (plat.ID == BtnID)
            {
                plat.ShowAndUnlockAllButton();
            }
            else
            {
                plat.HideAndlockAllButton();
            }
        }
    }
}
