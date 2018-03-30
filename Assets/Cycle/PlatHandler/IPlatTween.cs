using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IPlatTween  {
    protected Transform transform;
    public void SetProperty(Transform t)
    {
        transform = t;
    }
    public abstract void Show(bool isComplete);
    public abstract void Hide(bool isComplete);
}
