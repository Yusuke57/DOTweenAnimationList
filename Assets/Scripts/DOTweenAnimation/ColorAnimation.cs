using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace DOTweenAnimation
{
    public class ColorAnimation : MonoBehaviour, IAnimationPlayable
    {
        private Image[] squareImages;
        [SerializeField] private Color color1;
        [SerializeField] private Color color2;
        
        public void Play(float duration)
        {
            squareImages = GetComponentsInChildren<Image>();

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
                .Append(targetImage.DOColor(color2, duration / 2).SetEase(Ease.OutQuart))
                .AppendInterval(delay / 2)
                .Append(targetImage.DOColor(color1, duration / 2).SetEase(Ease.OutQuart))
                .AppendInterval(delay / 2)
                .SetLoops(-1);
        }
    }
}