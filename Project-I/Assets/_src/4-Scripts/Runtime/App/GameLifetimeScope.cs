using System.Collections.Generic;
using PorjectI.Services;
using PorjectI.UI;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace PorjectI.App
{
    public class GameLifetimeScope : LifetimeScope
    {
        [SerializeField] private List<ScriptableObject> configs = new();
        [SerializeField] private List<MonoBehaviour> controllers = new();

        protected override void Configure(IContainerBuilder builder)
        {
            Debug.Log($"System : Start Configure");

            RegisterConfigs(builder);
            RegisterControllers(builder);
            RegisterServices(builder);

            Debug.Log($"System : End Configure");
        }

        private void RegisterConfigs(IContainerBuilder builder)
        {
            Debug.Log($"System : Start Register Configs");

            foreach (var config in configs)
            {
                Debug.Log($"Register : {config.name}");

                builder.RegisterComponent(config).AsSelf();
            }

            Debug.Log($"System : End Register Configs");
        }

        private void RegisterControllers(IContainerBuilder builder)
        {
            Debug.Log($"System : Start Register Controllers");

            foreach (var controller in controllers) 
            {
                Debug.Log($"Register : {controller.name}");

                builder.RegisterInstance(controller).AsSelf();
            }

            Debug.Log($"System : End Register Controllers");
        }

        private void RegisterServices(IContainerBuilder builder)
        {
            Debug.Log($"System : Start Register Services");

            Debug.Log($"System : Register {nameof(RouterService)}");
            builder.Register<RouterService>(Lifetime.Singleton).AsImplementedInterfaces();

            Debug.Log($"System : End Register Services");
        }
    }
}