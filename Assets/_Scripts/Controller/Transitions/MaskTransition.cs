using System;
using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace PROTransition{

    public class MaskTransition : Transition
    {
        private SpriteMask _spriteMask;
        private SpriteRenderer _spriteMaskBackground;

        public MaskTransition(TransitionInfo transitionInfo, int sceneId, bool async, Action action = null) : base(transitionInfo, sceneId, async, action)
        {
        }

        public override void Play(List<GameObject> sources)
        { 
            //Setup variables for anim
            _spriteMask = sources[0].GetComponent<SpriteMask>();
            _spriteMaskBackground = sources[1].GetComponent<SpriteRenderer>();

            //Set the imageSource
            _spriteMaskBackground.color = _transitionInfo._color;

            //Run Anim
            Run(_action);
        }

        public void Run(Action action) {
            _spriteMask.gameObject.SetActive(true);
            _spriteMaskBackground.gameObject.SetActive(true);

            _spriteMask.transform.DOScale(Vector3.zero, _transitionInfo._totalTime / 2).SetEase(_transitionInfo._ease).OnComplete(() => {
                AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(_sceneId);
                PROTransitionManager.Instance.LoadSceneAsync(_sceneId, asyncOperation);
                _action?.Invoke();
                asyncOperation.allowSceneActivation = true;
            }).Play();
        }

        public override void Restart(Action action = null)
        {
            _spriteMask.transform.DOScale(Vector3.one * 15, _transitionInfo._totalTime/2).SetEase(_transitionInfo._ease).OnComplete(() => {
                _spriteMask.gameObject.SetActive(false);
                _spriteMaskBackground.gameObject.SetActive(false);
                PROTransitionManager.Instance.SetCurrentTransition(null);
            }).Play();
        }
    }
}


