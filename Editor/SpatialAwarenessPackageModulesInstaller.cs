// Copyright (c) Reality Collective. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using RealityCollective.ServiceFramework.Definitions;
using RealityCollective.ServiceFramework.Editor.Packages;
using RealityCollective.ServiceFramework.Services;
using UnityEditor;

namespace RealityToolkit.SpatialAwareness.Editor
{
    /// <summary>
    /// Installs <see cref="Ispatial_awarenessModule"/>s coming from a third party package
    /// into the <see cref="spatial_awarenessProfile"/> in the <see cref="ServiceManager.ActiveProfile"/>.
    /// </summary>
    [InitializeOnLoad]
    public sealed class SpatialAwarenessPackageModulesInstaller : IPackageModulesInstaller
    {
        /// <summary>
        /// Static initializer for the installer instance.
        /// </summary>
        static SpatialAwarenessPackageModulesInstaller()
        {
            if (Instance == null)
            {
                Instance = new SpatialAwarenessPackageModulesInstaller();
            }

            PackageInstaller.RegisterModulesInstaller(Instance);
        }

        /// <summary>
        /// Internal singleton instance of the installer.
        /// </summary>
        private static SpatialAwarenessPackageModulesInstaller Instance { get; }

        /// <inheritdoc/>
        public bool Install(ServiceConfiguration serviceConfiguration)
        {
            /*
            -------------------------------------------------------
            TO install modules for the service, uncomment the code below.

            Note, in order to correctly assign modules for the service, you need to replace the following (Where spatial_awareness is the service name used to generate this repository):

            - spatial_awareness with the correct service type.
            - spatial_awarenessModule with the correct module type.
            - Ispatial_awarenessModule with the correct module interface.
            - spatial_awarenessProfile with the correct profile type.

            These are collated from the service and module definitions generated using the Service Template Generator
            -------------------------------------------------------
                        if (!typeof(Ispatial_awarenessModule).IsAssignableFrom(serviceConfiguration.InstancedType.Type))
                        {
                            // This module installer does not accept the configuration type.
                            return false;
                        }

                        if (!ServiceManager.IsActiveAndInitialized)
                        {
                            UnityEngine.Debug.LogWarning($"Could not install {serviceConfiguration.InstancedType.Type.Name}.{nameof(ServiceManager)} is not initialized.");
                            return false;
                        }

                        if (!ServiceManager.Instance.HasActiveProfile)
                        {
                            UnityEngine.Debug.LogWarning($"Could not install {serviceConfiguration.InstancedType.Type.Name}.{nameof(ServiceManager)} has no active profile.");
                            return false;
                        }

                        if (!ServiceManager.Instance.TryGetServiceProfile<Ispatial_awareness, spatial_awarenessProfile>(out var spatial_awarenessProfile))
                        {
                            UnityEngine.Debug.LogWarning($"Could not install {serviceConfiguration.InstancedType.Type.Name}.{nameof(spatial_awarenessProfile)} not found.");
                            return false;
                        }

                        // Setup the configuration.
                        var typedServiceConfiguration = new ServiceConfiguration<Ispatial_awarenessModule>(serviceConfiguration.InstancedType.Type, serviceConfiguration.Name, serviceConfiguration.Priority, serviceConfiguration.RuntimePlatforms, serviceConfiguration.Profile);

                        // Make sure it is not already in the target profile.
                        if (spatial_awarenessProfile.ServiceConfigurations.All(sc => sc.InstancedType.Type != serviceConfiguration.InstancedType.Type))
                        {
                            spatial_awarenessProfile.AddConfiguration(typedServiceConfiguration);
                            UnityEngine.Debug.Log($"Successfully installed the {serviceConfiguration.InstancedType.Type.Name} to {spatial_awarenessProfile.name}.");
                        }
                        else
                        {
                            UnityEngine.Debug.Log($"Skipped installing the {serviceConfiguration.InstancedType.Type.Name} to {spatial_awarenessProfile.name}. Already installed.");
                        }
            */
            return true;
        }
    }
}
