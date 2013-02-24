﻿// MvxServiceProviderExtensions.cs
// (c) Copyright Cirrious Ltd. http://www.cirrious.com
// MvvmCross is licensed using Microsoft Public License (Ms-PL)
// Contributions and inspirations noted in readme.md and license.txt
// 
// Project Lead - Stuart Lodge, @slodge, me@slodge.com

using System;
using Cirrious.CrossCore.Platform;

namespace Cirrious.CrossCore.Interfaces.ServiceProvider
{
    public static class MvxServiceProviderExtensions
    {
        public static bool IsServiceAvailable<TService>() where TService : class
        {
            var factory = MvxServiceProvider.Instance;

            if (factory == null)
                return false;

            return factory.SupportsService<TService>();
        }

        public static bool IsServiceAvailable<TService>(this IMvxConsumer consumer) where TService : class
        {
            return IsServiceAvailable<TService>();
        }

        public static TService GetService<TService>(this IMvxConsumer consumer) where TService : class
        {
            return GetService<TService>();
        }

        public static TService GetService<TService>() where TService : class
        {
            var factory = MvxServiceProvider.Instance;

            if (factory == null)
                return default(TService);

            return factory.GetService<TService>();
        }

        public static bool TryGetService<TService>(this IMvxConsumer consumer, out TService service)
            where TService : class
        {
            return TryGetService(out service);
        }

        public static bool TryGetService<TService>(out TService service) where TService : class
        {
            var factory = MvxServiceProvider.Instance;

            if (factory == null)
            {
                service = default(TService);
                return false;
            }

            return factory.TryGetService(out service);
        }

        public static void RegisterServiceInstance<TInterface>(this IMvxServiceProducer producer,
                                                               Func<TInterface> serviceConstructor)
            where TInterface : class
        {
            var registry = MvxServiceProvider.Instance;
            registry.RegisterServiceInstance(serviceConstructor);
        }

        public static void RegisterServiceInstance<TInterface>(this IMvxServiceProducer producer,
                                                               TInterface service)
            where TInterface : class
        {
            var registry = MvxServiceProvider.Instance;
            registry.RegisterServiceInstance(service);
        }

        public static void RegisterServiceType<TInterface, TType>(this IMvxServiceProducer producer)
            where TInterface : class
            where TType : class, TInterface
        {
            var registry = MvxServiceProvider.Instance;
            registry.RegisterServiceType<TInterface, TType>();
        }
    }
}