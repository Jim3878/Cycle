using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Cycle
{
    [CustomEditor(typeof(ButtonEventTrigger))]
    public class ButtonEventTriggerInspector : Editor
    {
        ButtonEventTrigger trigger;
        private void OnEnable()
        {
            trigger = (ButtonEventTrigger)target;
            if (trigger.eventTrigger == null)
            {
                trigger.eventTrigger = trigger.GetComponent<CycleEventTrigger>();
            }
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            
        }
    }

}