// Copyright (c) Reality Collective. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information. 

using RealityCollective.ServiceFramework.Services;
using RealityCollective.Utilities.Editor;
using RealityToolkit.SpatialAwareness.Definitions;
using UnityEditor;
using UnityEngine;

namespace RealityToolkit.SpatialAwareness.Editor
{
    [InitializeOnLoad]
    public static class EditorActiveProfileChangeHandler
    {
        static EditorActiveProfileChangeHandler()
        {
            EditorApplication.hierarchyChanged += EditorApplication_hierarchyChanged;
        }

        private static void EditorApplication_hierarchyChanged()
        {
            if (ServiceManager.IsActiveAndInitialized)
            {
                if (ServiceManager.Instance.TryGetService<ISpatialAwarenessService>(out _) &&
                    LayerUtilities.CheckLayers(SpatialAwarenessSystemProfile.SpatialAwarenessLayers))
                {
                    Debug.Log($"{nameof(ISpatialAwarenessService)} was enabled, spatial mapping layers added to project.");
                }
                else if (!ServiceManager.Instance.TryGetService<ISpatialAwarenessService>(out _) &&
                         LayerUtilities.RemoveLayers(SpatialAwarenessSystemProfile.SpatialAwarenessLayers))
                {
                    Debug.Log($"{nameof(ISpatialAwarenessService)} was disabled, spatial mapping layers removed to project.");
                }
            }
        }
    }
}
