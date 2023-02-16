using System;
using System.Collections.Generic;
using UnityEngine;

namespace PROTransition
{
    public class Transition
    {
        public TransitionInfo _transitionInfo;
        protected int _sceneId;
        public Action _action;
        public bool _async;
   
        public Transition(TransitionInfo transitionInfo, int sceneId, bool async, Action? action = null)
        {
            _transitionInfo = transitionInfo;
            _sceneId = sceneId;
            _async = async;
            _action = action;
        }

        //Play the animaction, sources contains all gameobjects neccesary for the proccess
        public virtual void Play(List<GameObject> sources) {
        }

        //Restart the animation, you need this for restore the animation status. You must need this when change scenes
        public virtual void Restart(Action? action= null) { }
    }
}

