using UnityEngine;

namespace ProjectI.Game.Collectables
{
    [RequireComponent(typeof(BoxCollider))]
    public abstract class CollectableItem : MonoBehaviour
    {
        protected virtual void Awake()
        {
            GetComponent<BoxCollider>().isTrigger = true;
        }

        protected abstract void ApplyCollectable();

        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.CompareTag("Player"))
            {
                ApplyCollectable();

                Destroy(gameObject);
            }
        }
    }
}