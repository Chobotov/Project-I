using System.Collections.Generic;
using PorjectI.Services;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace PorjectI.App
{
    public class GameLifetimeScope : LifetimeScope
    {
        [SerializeField] private List<ScriptableObject> configs = new();

        protected override void Configure(IContainerBuilder builder)
        {
            Debug.Log($"System : Start Configure");
            
            RegisterConfigs(builder);
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

        private static void RegisterServices(IContainerBuilder builder)
        {
            Debug.Log($"System : Start Register Services");
            
            Debug.Log($"System : Register {nameof(RouterService)}");
            builder.Register<RouterService>(Lifetime.Singleton).AsSelf().As<IRouterService>();
            
            Debug.Log($"System : End Register Services");
        }
    }
}