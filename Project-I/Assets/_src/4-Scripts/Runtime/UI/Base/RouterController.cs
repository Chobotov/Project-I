using System;
using System.Collections.Generic;
using ProjectI.Configs.UI;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace ProjectI.UI
{
    public class RouterController : MonoBehaviour
    {
        private readonly Dictionary<Type, UIScreen> buffer = new();

        private RouterConfig config;

        private IObjectResolver resolver;

        private UIScreen currentScreen;

        [Inject]
        public void Inject(IObjectResolver resolver, RouterConfig config)
        {
            this.resolver = resolver;
            this.config = config;
        }

        public void Show<T>(RouterArgs args = null) where T : UIScreen
        {
            if (IsSameScreen<T>())
            {
                return;
            }

            var screen = TryGetOrCreate<T>();

            if (currentScreen)
            {
                currentScreen.Hide();
            }

            currentScreen = screen;

            currentScreen.Show(args);
        }

        private bool IsSameScreen<T>() where T : UIScreen
        {
            if (currentScreen && currentScreen is T)
            {
                return true;
            }

            return false;
        }

        private UIScreen TryGetOrCreate<T>() where T : UIScreen
        {
            if (!buffer.TryGetValue(typeof(T), out var screen))
            {
                screen = CreateScreen<T>();

                buffer.Add(typeof(T), screen);
            }

            return screen;
        }

        private UIScreen CreateScreen<T>() where T : UIScreen
        {
            var screenPrefab = config.GetScreen<T>();
            var screen = Instantiate(screenPrefab, transform);

            resolver.InjectGameObject(screen.gameObject);

            return screen;
        }
    }
}