using System;
using DG.Tweening;
using ProjectI.Game.Player;
using UnityEngine;

namespace ProjectI.Game.Enemies
{
    public class EnemyMove : IMoveble
    {
        private readonly Transform enemyTransform;
        private readonly Transform[] movePositions;

        private Transform currentTransform;

        private int indexTransform;

        public EnemyMove(Transform enemyTransform, Transform[] movePositions)
        {
            this.enemyTransform = enemyTransform;
            this.movePositions = movePositions;

            indexTransform = 0;
            currentTransform = movePositions[indexTransform];
        }

        public void Move(float speed)
        {
            if (currentTransform)
            {
                enemyTransform.position = Vector3.MoveTowards(
                    enemyTransform.position, 
                    currentTransform.position, 
                    speed * Time.deltaTime);

                enemyTransform.LookAt(currentTransform);

                if (Vector3.Distance(enemyTransform.position, currentTransform.position) < 0.001f)
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

        public void Jump(float jumpForce, Action? onFinish = null)
        {
            var endPos = enemyTransform.position + Vector3.back * 3;
            var jumpCount = 1;
            var duration = .5f;
 
            DOTween.Sequence()
                .AppendCallback(() => enemyTransform.DOScale(Vector3.zero, duration))
                .AppendCallback(() => enemyTransform.DORotate(Vector3.one * 180f, duration, RotateMode.FastBeyond360).SetLoops(-1))
                .Append(enemyTransform.DOJump(endPos, jumpForce, jumpCount, duration))
                .OnComplete(() => onFinish?.Invoke());
        }

        public void Move(float moveInput, float speed)
        {
        }
    }
}