using DG.Tweening;
using UnityEngine;

namespace DOTweenAnimation
{
    public class RotateAnimation : MonoBehaviour, IAnimationPlayable
    {
        [SerializeField] private RectTransform[] circleParents;

        public void Play(float duration)
        {
            duration /= 2;
            
            var delay = duration * 0.1f;
            for (var i = 0; i < circleParents.Length; i++)
            {
                var target = circleParents[i];
                var eachDelay = delay * i / (circleParents.Length - 1);
                DOVirtual.DelayedCall(eachDelay, () => PlayEachAnimation(target, duration - delay, delay));
            }
        }

        private void PlayEachAnimation(RectTransform target, float duration, float delay)
        {
            DOTween.Sequence()
                .Append(target.DORotate(Vector3.back * 360, duration, RotateMode.FastBeyond360).SetEase(Ease.InOutQuint))
                .AppendInterval(delay)
                .SetLoops(-1);
        }
    }
}