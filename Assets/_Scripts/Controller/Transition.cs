using System;
using UnityEngine.UI;

namespace PROTransition
{
    public class Transition
    {
        public TransitionInfo _transitionInfo;
        protected int _sceneId;
        public Action _action;
        public Image _source;
        public bool _async;
   
        public Transition(TransitionInfo transitionInfo, int sceneId, bool async, Action? action = null)
        {
            _transitionInfo = transitionInfo;
            _sceneId = sceneId;
            _async = async;
            _action = action;
        }

        public virtual void Play(Image source) { }
    }
}

