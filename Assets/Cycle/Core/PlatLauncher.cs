using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cycle {
    public class PlatLauncher : MonoBehaviour {

        public List<PlatInstance> platList;

        // Use this for initialization
        void Start() {
            foreach(var plat in platList)
            {
                (plat as PlatController).SetLock(false);
                UIManager.instance.RegistPlat(plat);
                if (plat.ID == 0)
                    (plat as PlatController).ShowAndUnlockAllButton(true);
            }
        }

    }
}