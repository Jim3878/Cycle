using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cycle {
    public abstract class IPlatHandler : MonoBehaviour {

        public abstract void Initialize(IPlatController controller);
    }
}