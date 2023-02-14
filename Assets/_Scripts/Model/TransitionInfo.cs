using UnityEngine;
using DG.Tweening;

namespace PROTransition
{
    public class TransitionInfo
    {
        public Color _color;
        public float _totalTime;
        public Ease _ease;
        public TransitionType _type;
        public TransitionOrigin _origin;

        public TransitionInfo(Color color, float totalTime, Ease ease, TransitionType type, TransitionOrigin origin)
        {
            _color = color;
            _totalTime = totalTime;
            _ease = ease;
            _type = type;
            _origin = origin;
        }
    }
}


