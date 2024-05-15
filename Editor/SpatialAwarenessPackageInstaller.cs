// Copyright (c) Reality Collective. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using RealityCollective.ServiceFramework.Editor;
using RealityCollective.ServiceFramework.Editor.Packages;
using RealityCollective.Utilities.Editor;
using RealityCollective.Utilities.Extensions;
using RealityToolkit.Editor;
using RealityToolkit.Editor.Settings;
using System.IO;
using UnityEditor;

namespace RealityToolkit.SpatialAwareness.Editor
{
    [InitializeOnLoad]
    internal static class SpatialAwarenessPackageInstaller
    {
        private static readonly string destinationPath = Path.Combine(RealityToolkitEditorSettings.Instance.AssetImportPath, "SpatialAwareness");
        private static readonly string sourcePath = Path.GetFullPath($"{PathFinderUtility.ResolvePath<IPathFinder>(typeof(SpatialAwarenessPathFinder)).ForwardSlashes()}{Path.DirectorySeparatorChar}{RealityToolkitPreferences.HIDDEN_PACKAGE_ASSETS_PATH}");

        static SpatialAwarenessPackageInstaller()
        {
            EditorApplication.delayCall += CheckPackage;
        }

        [MenuItem(RealityToolkitPreferences.Editor_Menu_Keyword + "/Packages / Install Spatial Awareness Package Assets...", true)]
        private static bool ImportPackageAssetsValidation()
        {
            return !Directory.Exists($"{destinationPath}{Path.DirectorySeparatorChar}");
        }

        [MenuItem(RealityToolkitPreferences.Editor_Menu_Keyword + "/Packages / Install Spatial Awareness Package Assets...")]
        private static void ImportPackageAssets()
        {
            EditorPreferences.Set($"{nameof(SpatialAwarenessPackageInstaller)}.Assets", false);
            EditorApplication.delayCall += CheckPackage;
        }

        private static void CheckPackage()
        {
            if (!EditorPreferences.Get($"{nameof(SpatialAwarenessPackageInstaller)}.Assets", false))
            {
                EditorPreferences.Set($"{nameof(SpatialAwarenessPackageInstaller)}.Assets", AssetsInstaller.TryInstallAssets(sourcePath, destinationPath));
            }
        }
    }
}
