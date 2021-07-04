using DG.Tweening;
using UnityEngine;

namespace DOTweenAnimation
{
    /// <summary>
    /// アニメーションを一括再生
    /// </summary>
    public class AnimationPlayer : MonoBehaviour
    {
        [SerializeField] private float duration;
        
        private void Start()
        {
            DOVirtual.DelayedCall(0.5f, Play);
        }

        /// <summary>
        /// 子孫にあるIAnimationPlayableを一括再生
        /// </summary>
        private void Play()
        {
            var playables = GetComponentsInChildren<IAnimationPlayable>();
            if (playables == null) return;
            
            foreach (var playable in playables)
            {
                playable.Play(duration);
            }
        }
    }
}