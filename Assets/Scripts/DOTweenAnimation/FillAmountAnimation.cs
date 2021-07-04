using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace DOTweenAnimation
{
    public class FillAmountAnimation : MonoBehaviour, IAnimationPlayable
    {
        [SerializeField] private Image circleImage;
        [SerializeField] private Image[] squareImages;

        public void Play(float duration)
        {
            duration /= 2;
            
            // 円
            DOTween.Sequence()
                .Append(circleImage.DOFillAmount(1, duration / 2).SetEase(Ease.InOutQuart))
                .AppendCallback(() => circleImage.fillClockwise = !circleImage.fillClockwise)
                .Append(circleImage.DOFillAmount(0, duration / 2).SetEase(Ease.InOutQuart))
                .AppendCallback(() => circleImage.fillClockwise = !circleImage.fillClockwise)
                .SetLoops(-1);
            
            // 線
            var startDelay = duration * 0.3f;
            var endDelay = duration * 0.1f;
            var diffDelay = duration * 0.1f;
            var sumDelay = startDelay + endDelay + diffDelay;
            for (var i = 0; i < squareImages.Length; i++)
            {
                var target = squareImages[i];
                DOVirtual.DelayedCall(diffDelay * i, 
                    () => PlayEachLineAnimation(target, duration - sumDelay, startDelay + diffDelay, endDelay));
            }
        }

        private void PlayEachLineAnimation(Image targetImage, float duration, float startDelay, float endDelay)
        {
            DOTween.Sequence()
                .AppendInterval(startDelay)
                .Append(targetImage.DOFillAmount(1, duration / 2).SetEase(Ease.OutQuart))
                .AppendCallback(() => targetImage.fillOrigin = (int)Image.OriginHorizontal.Right)
                .Append(targetImage.DOFillAmount(0, duration / 2).SetEase(Ease.OutQuart))
                .AppendCallback(() => targetImage.fillOrigin = (int) Image.OriginHorizontal.Left)
                .AppendInterval(endDelay)
                .SetLoops(-1);
        }
    }
}