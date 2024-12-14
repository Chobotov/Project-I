using ProjectI.Game.Player;
using UnityEngine;

namespace ProjectI.Game.Enemies
{
    [RequireComponent(typeof(BoxCollider))]
    public class Trap : MonoBehaviour
    {
        [SerializeField] private int damage;
        [SerializeField] private float damageForce = 15f;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent<IDamageble>(out var damageble))
            {
                damageble.SetDamage(damage);

                var force = (collision.gameObject.transform.position - transform.position).normalized;

                collision.rigidbody.AddForce(force * damageForce, ForceMode.Impulse);
            }
        }
    }
}