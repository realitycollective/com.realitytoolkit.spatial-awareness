﻿// Copyright (c) Reality Collective. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.﻿

using RealityCollective.ServiceFramework.Editor.Profiles;
using RealityToolkit.Editor;
using RealityToolkit.SpatialAwareness.Definitions;
using UnityEditor;
using UnityEngine;

namespace RealityToolkit.SpatialAwareness.Editor
{
    [CustomEditor(typeof(SpatialAwarenessSystemProfile))]
    public class SpatialAwarenessSystemProfileInspector : ServiceProfileInspector
    {
        private SerializedProperty meshDisplayOption;
        private SerializedProperty globalMeshObserverProfile;
        private SerializedProperty globalSurfaceObserverProfile;

        private readonly GUIContent generalSettingsFoldoutHeader = new GUIContent("General Settings");

        /// <inheritdoc />
        protected override void OnEnable()
        {
            base.OnEnable();

            meshDisplayOption = serializedObject.FindProperty(nameof(meshDisplayOption));
            meshDisplayOption.isExpanded = true;
            globalMeshObserverProfile = serializedObject.FindProperty(nameof(globalMeshObserverProfile));
            globalSurfaceObserverProfile = serializedObject.FindProperty(nameof(globalSurfaceObserverProfile));
        }

        /// <inheritdoc />
        protected override void RenderConfigurationOptions(bool forceExpanded = false)
        {
            RenderHeader("Spatial Awareness can enhance your experience by enabling objects to interact with the real world.\n\nBelow is a list of registered Spatial Observers that can gather data about your environment.");

            serializedObject.Update();

            if (meshDisplayOption.FoldoutWithBoldLabelPropertyField(generalSettingsFoldoutHeader))
            {
                EditorGUILayout.Space();
                EditorGUI.indentLevel++;
                EditorGUILayout.PropertyField(globalMeshObserverProfile);
                EditorGUILayout.PropertyField(globalSurfaceObserverProfile);
                EditorGUI.indentLevel--;
            }

            DrawServiceModulePropertyDrawer();

            serializedObject.ApplyModifiedProperties();
        }
    }
}