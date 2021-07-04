using DG.Tweening;
using UnityEngine;

namespace DOTweenAnimation
{
    public class MoveAnimation : MonoBehaviour, IAnimationPlayable
    {
        [SerializeField] private RectTransform square1;
        [SerializeField] private RectTransform square2;
        
        public void Play(float duration)
        {
            duration /= 2;
            
            PlayEachAnimation(square1, duration);
            PlayEachAnimation(square2, duration);
        }

        private void PlayEachAnimation(RectTransform target, float duration)
        {
            var pos = target.anchoredPosition;

            DOTween.Sequence()
                .Append(target.DOAnchorPosX(-pos.x, duration / 4).SetEase(Ease.InOutQuart))
                .Append(target.DOAnchorPosY(-pos.y, duration / 4).SetEase(Ease.InOutQuart))
                .Append(target.DOAnchorPosX(pos.x, duration / 4).SetEase(Ease.InOutQuart))
                .Append(target.DOAnchorPosY(pos.y, duration / 4).SetEase(Ease.InOutQuart))
                .SetLoops(-1);
        }
    }
}
