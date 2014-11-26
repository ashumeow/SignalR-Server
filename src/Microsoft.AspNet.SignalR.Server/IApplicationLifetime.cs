﻿// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Threading;
using Microsoft.Framework.Runtime;

namespace Microsoft.AspNet.Hosting
{
    /// <summary>
    /// Allows consumers to perform blocking cleanup during a graceful shutdown.
    /// </summary>
    [AssemblyNeutral]
    public interface IApplicationLifetime
    {
        /// <summary>
        /// Triggered when the application host is performing a graceful shutdown.
        /// Request may still be in flight. Shutdown will block until this event completes.
        /// </summary>
        /// <returns></returns>
        CancellationToken ApplicationStopping { get; }

        /// <summary>
        /// Triggered when the application host is performing a graceful shutdown.
        /// All requests should be complete at this point. Shutdown will block
        /// until this event completes.
        /// </summary>
        /// <returns></returns>
        CancellationToken ApplicationStopped { get; }
    }
}