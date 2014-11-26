﻿using System;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.Framework.DependencyInjection;
using Xunit;

namespace Microsoft.AspNet.SignalR.Tests
{
    public class HubManagerExtensionsFacts
    {
        [Fact]
        public void EnsureHubThrowsWhenCantResolve()
        {
            var sp = ServiceProviderHelper.CreateServiceProvider();
            var ta = new TypeActivator();
            var hubManager = ta.CreateInstance<DefaultHubManager>(sp);

            Assert.Throws<InvalidOperationException>(() => hubManager.EnsureHub("__ELLO__"));
        }

        [Fact]
        public void EnsureHubSuccessfullyResolves()
        {
            var sp = ServiceProviderHelper.CreateServiceProvider();
            var ta = new TypeActivator();
            var hubManager = ta.CreateInstance<DefaultHubManager>(sp);
            var TestHubName = "CoreTestHubWithMethod";

            HubDescriptor hub = null,
                          actualDescriptor = hubManager.GetHub(TestHubName);

            Assert.DoesNotThrow(() =>
            {
                hub = hubManager.EnsureHub(TestHubName);
            });

            Assert.Equal(hub, actualDescriptor);
        }
    }
}
