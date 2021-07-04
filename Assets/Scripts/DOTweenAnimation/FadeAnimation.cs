using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace DOTweenAnimation
{
    public class FadeAnimation : MonoBehaviour, IAnimationPlayable
    {
        [SerializeField] private Transform squareParent;
        private Image[] squareImages;

        public void Play(float duration)
        {
            squareImages = squareParent.GetComponentsInChildren<Image>();

            duration /= 2;
            
            var delay = duration * 0.2f;
            for (var i = 0; i < squareImages.Length; i++)
            {
                var target = squareImages[i];
                var eachDelay = delay * i / (squareImages.Length - 1);
                DOVirtual.DelayedCall(eachDelay, () => PlayEachAnimation(target, duration - delay, delay));
            }
        }

        private void PlayEachAnimation(Image targetImage, float duration, float delay)
        {
            DOTween.Sequence()
                .Append(targetImage.DOFade(0, duration / 4).SetEase(Ease.OutQuart))
                .AppendInterval(duration / 4 + delay / 2)
                .Append(targetImage.DOFade(1, duration / 4).SetEase(Ease.OutQuart))
                .AppendInterval(duration / 4 + delay / 2)
                .SetLoops(-1);
        }
    }
}