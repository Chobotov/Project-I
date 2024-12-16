using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace ProjectI.Game.Enemies
{
    [RequireComponent(typeof(BoxCollider), typeof(Rigidbody))]
    public class TimelyPlatform : MonoBehaviour
    {
        [SerializeField] private float duration;

        private Rigidbody rigidbody;
        private bool isFalling;

        private void Awake()
        {
            rigidbody = GetComponent<Rigidbody>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (!isFalling && collision.gameObject.CompareTag("Player"))
            {
                StartFalling();
            }
        }

        private void StartFalling()
        {
            isFalling = true;

            transform
                .DOShakePosition(
                    duration: duration,
                    strength: .5f,
                    vibrato: 2)
                .OnComplete(Fall)
                .SetTarget(transform);
        }

        private async void Fall()
        {
            rigidbody.isKinematic = false;
            rigidbody.useGravity = true;

            await UniTask.Delay(TimeSpan.FromSeconds(1.5f));

            if (gameObject)
            {
                Destroy(gameObject);
            }
        }
    }
}