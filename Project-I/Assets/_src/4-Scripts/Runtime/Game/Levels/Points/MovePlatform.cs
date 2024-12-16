using System;
using UnityEngine;

namespace ProjectI.Game.Levels
{
    [RequireComponent(typeof(BoxCollider))]
    public class MovePlatform : MonoBehaviour
    {
        [SerializeField] private Transform[] movePositions;
        [SerializeField] private Transform platform;
        [SerializeField] private float speed;

        private Transform currentTransform;
        private int indexTransform;

        private Transform prevParent;

        public Transform[] MovePositions => movePositions;

        private void Awake()
        {
            indexTransform = 0;
            currentTransform = movePositions[indexTransform];
        }

        public void Update()
        {
            if (currentTransform)
            {
                platform.position = Vector3.MoveTowards(
                    platform.position, 
                    currentTransform.position, 
                    speed * Time.deltaTime);

                if (Vector3.Distance(platform.position, currentTransform.position) < 0.001f)
                {
                    SwitchPosition();
                }
            }
        }

        private void SwitchPosition()
        {
            if (indexTransform >= movePositions.Length - 1)
            {
                indexTransform = 0;
            }
            else
            {
                indexTransform++;
            }

            currentTransform = movePositions[indexTransform];
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                prevParent = other.gameObject.transform.parent;

                other.gameObject.transform.SetParent(transform);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                other.gameObject.transform.SetParent(prevParent);
                prevParent = null;
            }
        }
    }
}