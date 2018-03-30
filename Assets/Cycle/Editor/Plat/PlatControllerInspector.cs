using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Cycle
{
    [CustomEditor(typeof(PlatController))]
    public class PlatControllerInspector : Editor
    {
        private PlatController controller;
        private void OnEnable()
        {
            controller = target as PlatController;
        }

        private bool isShowAllButton;

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (Application.isPlaying)
            {
                EditorGUI.BeginChangeCheck();
                bool isLock = GUILayout.Toggle(controller.isLock, "isLock");
                if (EditorGUI.EndChangeCheck())
                {
                    controller.SetLock(isLock);
                }
                if (!isLock)
                {
                    DrawPlatController();
                }
            }
        }

        private void DrawPlatController()
        {
            if (GUILayout.Button(controller.isShow ? "Hide" : "Show"))
            {
                if (controller.isShow)
                {
                    controller.Hide();
                }
                else
                {
                    controller.Show();
                }
            }
            isShowAllButton = EditorGUILayout.Foldout(isShowAllButton, "Button List");
            if (isShowAllButton)
            {
                DrawButtonList();
            }
        }

        private void DrawButtonList()
        {
            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("Lock All"))
            {
                controller.SetAllButtonLock(true);
            }
            if (GUILayout.Button("Unlock All"))
            {
                controller.SetAllButtonLock(false);
            }
            EditorGUILayout.EndHorizontal();

            foreach (var btn in controller.GetAllButton())
            {
                DrawButtonItem(btn);
            }
        }

        private void DrawButtonItem(IButtonInstance btn)
        {
            var btnCtrl = btn as IButtonController;
            EditorGUI.BeginChangeCheck();
            GUILayout.BeginHorizontal();

            EditorGUI.BeginChangeCheck();
            var isLock = GUILayout.Toggle(btnCtrl.isLock, "isLock");
            EditorGUILayout.LabelField(string.Format("ID [{0}]", btn.ID));
            if (EditorGUI.EndChangeCheck())
            {
                btnCtrl.SetLock(isLock);
            }

            GUILayout.EndHorizontal();
            if (EditorGUI.EndChangeCheck())
            {
                UnityEditor.EditorGUIUtility.PingObject((btn).gameObject);
            }
        }
    }
}