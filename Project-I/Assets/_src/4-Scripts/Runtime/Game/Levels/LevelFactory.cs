using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace ProjectI.Game.Levels
{
    public class LevelFactory : MonoBehaviour
    {
        private IObjectResolver resolver;
        private ILevelService levelService;

        private LevelController levelField;

        public LevelController LevelField => levelField;

        [Inject]
        internal void Inject(IObjectResolver resolver, ILevelService levelService)
        {
            this.resolver = resolver;
            this.levelService = levelService;
        }

        public void CreateLevelField()
        {
            var field = levelService.GetLevelField();
            levelField = Instantiate(field, transform);

            resolver.InjectGameObject(levelField.gameObject);
        }

        public void ClearField()
        {
            Destroy(levelField.gameObject);
        }
    }
}