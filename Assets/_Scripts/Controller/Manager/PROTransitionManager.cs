using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PROTransition
{
    public partial class PROTransitionManager : UnitySingletonPersistent<PROTransitionManager>
    {
        [Header("Fade")]
        public GameObject _transitionSquare;

        [Header("Horizontal")]
        public GameObject _horizontalSquare;

        [Header("Mask")]
        public GameObject _mask; 
        public GameObject _maskBackground;

        [Header("Others")]
        public Transition _currentTransition;

        public void Play(Transition transition)
        {
            _currentTransition = transition;
            List<GameObject> sources = new List<GameObject>();

            //Set sources per transition type: sources are usefull for play the transition anim above them
            switch (transition._transitionInfo._type) {

                case TransitionType.Fade:
                    sources.Add(_transitionSquare);
                    break;
                case TransitionType.Filled:
                    sources.Add(_horizontalSquare);
                    break;
                case TransitionType.Mask:
                    sources.Add(_mask);
                    sources.Add(_maskBackground);
                    break;
            }

            _currentTransition.Play(sources);
        }

        public void Restart(Action? restartAction = null) {

            if (_currentTransition == null) {
                Debug.LogWarning("Doesnt have _currentTransition");
                return;
            }

            _currentTransition.Restart(restartAction);
        }

        public void SetCurrentTransition(Transition newTransition)
        {
            _currentTransition = newTransition;
        }

        protected IEnumerator LoadSceneAsyncCoroutine(int sceneID)
        {
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneID);
            asyncOperation.allowSceneActivation = false;

            while (!asyncOperation.isDone)
            {
                if (asyncOperation.progress >= 0.9f)
                {
                    asyncOperation.allowSceneActivation = true;
                }

                yield return null;
            }
        }

        internal void LoadSceneAsync(int sceneID)
        {
            StartCoroutine(LoadSceneAsyncCoroutine(sceneID));
        }
    }
}

