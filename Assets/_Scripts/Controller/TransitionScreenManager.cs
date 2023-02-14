using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace PROTransition
{
    public partial class TransitionScreenManager : UnitySingletonPersistent<TransitionScreenManager>
    {
        public Image _transitionSquare;
        public Image _transitionCircle;
        public Transition _currentTransition;

        public void Play(Transition transition)
        {
            _currentTransition = transition;

            _currentTransition.Play(_transitionSquare);
        }

        public void Play()
        {
            if (_currentTransition == null)
                Debug.LogError("Curret Transition is empty");

            _currentTransition.Play(_transitionSquare);
        }

        public void Restart(Action? restartAction = null) {
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

