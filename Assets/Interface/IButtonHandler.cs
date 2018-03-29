using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cycle
{
    [System.Serializable]
    public abstract class IButtonHandler:MonoBehaviour
    {
        public abstract void Initialize(IButtonController controller);

    }
}