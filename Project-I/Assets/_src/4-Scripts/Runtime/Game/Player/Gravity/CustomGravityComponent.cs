using UnityEngine;

namespace ProjectI.Game.Player
{
    public class CustomGravityComponent : MonoBehaviour
    {
        [SerializeField] private float gravityScale;
        [SerializeField] private float gravity;

        public float GravityScale => gravityScale;

        public float Gravity => gravity;

        public void HandleGravity(Rigidbody rigidbody)
        {
            rigidbody.AddForce(Vector3.down * gravity, ForceMode.Acceleration);
        }
    }
}