﻿// Copyright (c) Reality Collective. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using UnityEngine.EventSystems;

namespace RealityToolkit.SpatialAwareness.Interfaces.Handlers
{
    /// <summary>
    /// The event handler for all Spatial Awareness Mesh Events.
    /// </summary>
    public interface ISpatialAwarenessMeshHandler<T> : IEventSystemHandler
    {
        /// <summary>
        /// Called when the spatial awareness mesh subsystem adds a mesh.
        /// </summary>
        /// <param name="eventData">Data describing the event.</param>
        void OnMeshAdded(SpatialAwarenessEventData<T> eventData);

        /// <summary>
        /// Called when the spatial awareness mesh subsystem updates an existing mesh.
        /// </summary>
        /// <param name="eventData">Data describing the event.</param>
        void OnMeshUpdated(SpatialAwarenessEventData<T> eventData);

        /// <summary>
        /// Called when the spatial awareness mesh subsystem removes an existing mesh.
        /// </summary>
        /// <param name="eventData">Data describing the event.</param>
        void OnMeshRemoved(SpatialAwarenessEventData<T> eventData);
    }
}
