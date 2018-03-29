using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cycle;

public class TriggerSample : IButtonTrigger
{
    public List<ButtonController> ctrlList;
    //private void Start()
    //{
    //    foreach(var btn in ctrlList)
    //    {
    //        btn.AddButtonComponent(this);
    //    }
    //}

    protected override void Trigger(int platID, int BtnID)
    {
        switch (BtnID)
        {
            case 1:
                Debug.Log("Btn A Trigger");
                break;
            case 2:
                Debug.Log("Btn B Trigger");
                break;
            case 3:
                Debug.Log("Btn C Trigger");
                break;
        }
    }
}
