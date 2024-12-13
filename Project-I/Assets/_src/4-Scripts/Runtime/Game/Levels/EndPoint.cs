using Cysharp.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using VContainer;

namespace ProjectI.Game.Levels
{
    [RequireComponent(typeof(BoxCollider))]
    public class EndPoint : MonoBehaviour
    {
        private ILevelService levelService;

        private BoxCollider boxCollider;

        private void Awake()
        {
            boxCollider = GetComponent<BoxCollider>();
            boxCollider.isTrigger = true;
        }

        [Inject]
        public void Inject(ILevelService levelService)
        {
            this.levelService = levelService;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                CompleteLevel();

                boxCollider.enabled = false;
            }
        }

        private async void CompleteLevel()
        {
            await UniTask.Delay(1 * 1000);

            levelService.CompleteLevel();
        }
    }
}