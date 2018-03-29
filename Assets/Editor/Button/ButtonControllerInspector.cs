using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System;

namespace Cycle
{
    [CustomEditor(typeof(ButtonController))]
    public class ButtonControllerInspector : Editor
    {
        ButtonController ctrl;
        private void OnEnable()
        {
            ctrl = target as ButtonController;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            bool isLock = EditorGUILayout.Toggle("Lock", ctrl.isLock);
            if (Application.isPlaying && isLock != ctrl.isLock)
            {
                ctrl.SetLock(isLock);
            }
            if (Application.isPlaying && !isLock)
            {
                ButtonColorEnum state = (ButtonColorEnum)EditorGUILayout.EnumPopup("當前狀態", ctrl.currentState);
                if (Application.isPlaying && state != ctrl.currentState)
                {
                    ctrl.SetState(state);
                }
                if (GUILayout.Button("Trigger") && Application.isPlaying)
                {
                    ctrl.Trigger();
                }
            }
        }
    }
}