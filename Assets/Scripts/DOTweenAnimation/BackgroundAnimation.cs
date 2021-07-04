using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace DOTweenAnimation
{
    /// <summary>
    /// durationのタイミングの可視化用
    /// </summary>
    public class BackgroundAnimation : MonoBehaviour, IAnimationPlayable
    {
        [SerializeField] private bool isActive;
        
        [SerializeField] private Image image;
        
        public void Play(float duration)
        {
            if (!isActive) return;
            
            var color = image.color;

            DOTween.Sequence()
                .Append(image.DOColor(new Color(color.r + 0.1f, color.g + 0.1f, color.b + 0.1f), 0))
                .Append(image.DOColor(color, duration * 0.05f))
                .AppendInterval(duration * 0.95f)
                .SetLoops(-1);
        }
    }
}