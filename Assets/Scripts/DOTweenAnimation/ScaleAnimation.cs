using DG.Tweening;
using UnityEngine;

namespace DOTweenAnimation
{
    public class ScaleAnimation : MonoBehaviour, IAnimationPlayable
    {
        [SerializeField] private RectTransform largeSquare;
        [SerializeField] private RectTransform smallSquare;
        
        public void Play(float duration)
        {
            duration /= 2;
            
            DOTween.Sequence()
                .Append(smallSquare.DOScaleX(0, 0))
                .Append(smallSquare.DOScaleY(0.05f, 0))
                .Append(largeSquare.DOScaleX(1, duration / 6).SetEase(Ease.InQuart))
                .Append(largeSquare.DOScaleY(1, duration / 6).SetEase(Ease.OutQuart))
                .Append(smallSquare.DOScaleX(1, duration / 6).SetEase(Ease.OutQuad))
                .Append(smallSquare.DOScaleY(1, duration / 6).SetEase(Ease.OutQuart))
                .Append(largeSquare.DOScaleY(0.05f, duration / 6).SetEase(Ease.InQuart))
                .Append(largeSquare.DOScaleX(0, duration / 6).SetEase(Ease.OutQuart))
                .SetLoops(-1);
        }
    }
}