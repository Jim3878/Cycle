using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cycle;


public class ButtonInitializeTest : MonoBehaviour {

    public List<ButtonController> ctrl;

    private void Start()
    {
        foreach(var btn in ctrl)
        {
            btn.Initialize(null);
            btn.SetLock(false);
        }
    }

}
