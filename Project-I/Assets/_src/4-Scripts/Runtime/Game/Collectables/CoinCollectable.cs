using DG.Tweening;
using ProjectI.Game.Audio;
using UnityEngine;
using VContainer;

namespace ProjectI.Game.Collectables
{
    public class CoinCollectable : CollectableItem
    {
        private IAudioService audioService;

        [Inject]
        public void Inject(IAudioService audioService)
        {
            this.audioService = audioService;
        }

        protected override void Awake()
        {
            base.Awake();

            const float yOffset = 0.5f;

            var y = transform.localPosition.y;

            DOTween.Sequence()
                .Append(transform.DORotate(new Vector3(0, 360, 0), 1f, RotateMode.FastBeyond360))
                .Join(transform.DOLocalMoveY(y - yOffset, 1f))
                .SetEase(Ease.Linear)
                .SetLoops(-1, LoopType.Yoyo)
                .SetTarget(transform);
        }

        protected override void ApplyCollectable()
        {
            audioService.PlaySfx(AudioKeys.SfxCoin);
        }
    }
}