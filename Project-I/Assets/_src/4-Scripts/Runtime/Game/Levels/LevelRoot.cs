using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace ProjectI.Game.Levels
{
    public class LevelRoot : MonoBehaviour, IStartable, ITickable
    {
        private ILevelService levelService;

        [Inject]
        internal void Inject(ILevelService levelService)
        {
            this.levelService = levelService;
        }

        public void Start()
        {
        }

        public void Tick()
        {
        }
    }
}