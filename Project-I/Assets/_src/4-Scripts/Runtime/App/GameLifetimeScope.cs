using System.Collections.Generic;
using ProjectI.Game.Audio;
using ProjectI.Game.Levels;
using ProjectI.Services;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace ProjectI.App
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

            builder.RegisterEntryPoint<LevelFactory>();

            Debug.Log($"System : End Register Controllers");
        }

        private void RegisterServices(IContainerBuilder builder)
        {
            Debug.Log($"System : Start Register Services");

            Debug.Log($"System : Register {nameof(RouterService)}");
            builder.Register<IRouterService, RouterService>(Lifetime.Singleton);

            Debug.Log($"System : Register {nameof(AudioService)}");
            builder.Register<IAudioService, AudioService>(Lifetime.Singleton);

            Debug.Log($"System : Register {nameof(LevelService)}");
            builder.Register<ILevelService, LevelService>(Lifetime.Singleton);

            Debug.Log($"System : End Register Services");
        }
    }
}