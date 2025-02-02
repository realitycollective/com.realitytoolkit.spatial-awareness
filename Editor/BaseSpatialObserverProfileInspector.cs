﻿// Copyright (c) Reality Collective. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using RealityCollective.ServiceFramework.Editor.Profiles;
using RealityToolkit.Definitions.SpatialObservers;
using RealityToolkit.Editor;
using UnityEditor;
using UnityEngine;

namespace RealityToolkit.SpatialAwareness.Editor
{
    [CustomEditor(typeof(BaseSpatialObserverProfile), true, isFallback = true)]
    public abstract class BaseSpatialObserverProfileInspector : ServiceProfileInspector
    {
        private SerializedProperty startupBehavior;
        private SerializedProperty observationExtents;
        private SerializedProperty isStationaryObserver;
        private SerializedProperty updateInterval;
        private SerializedProperty physicsLayer;

        private readonly GUIContent generalSettingsFoldoutHeader = new GUIContent("General Settings");

        /// <inheritdoc />
        protected override void OnEnable()
        {
            base.OnEnable();

            startupBehavior = serializedObject.FindProperty(nameof(startupBehavior));
            startupBehavior.isExpanded = true;
            observationExtents = serializedObject.FindProperty(nameof(observationExtents));
            isStationaryObserver = serializedObject.FindProperty(nameof(isStationaryObserver));
            updateInterval = serializedObject.FindProperty(nameof(updateInterval));
            physicsLayer = serializedObject.FindProperty(nameof(physicsLayer));
        }

        /// <inheritdoc />
        protected override void RenderConfigurationOptions(bool forceExpanded = false)
        {
            RenderHeader("The Spatial Awareness Observer service module supplies the Spatial Awareness System with all the data it needs to understand the world around you.");

            serializedObject.Update();

            if (startupBehavior.FoldoutWithBoldLabelPropertyField(generalSettingsFoldoutHeader))
            {
                EditorGUI.indentLevel++;
                EditorGUILayout.PropertyField(observationExtents);
                EditorGUILayout.PropertyField(isStationaryObserver);
                EditorGUILayout.PropertyField(updateInterval);
                EditorGUILayout.PropertyField(physicsLayer);
                EditorGUI.indentLevel--;
            }

            EditorGUILayout.Space();

            DrawServiceModulePropertyDrawer();

            serializedObject.ApplyModifiedProperties();
        }
    }
}