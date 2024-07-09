using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using ProjectI.UI;
using UnityEngine;

namespace ProjectI.Configs.UI
{
    [CreateAssetMenu(fileName = "Router Config", menuName = "ProjectI/Configs/Router/Router Config", order = 0)]
    public class RouterConfig : ScriptableObject
    {
        [SerializeField] private List<UIScreen> screens = new();

        [CanBeNull]
        public T GetScreen<T>() where T : UIScreen
        {
            return screens.FirstOrDefault(x => x is T) as T;
        }
    }
}