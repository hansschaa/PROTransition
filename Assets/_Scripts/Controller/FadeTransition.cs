using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace PROTransition
{
    public class FadeTransition : Transition
    {
        public FadeTransition(TransitionInfo transitionInfo, int sceneId, bool async, Action action = null) : base(transitionInfo, sceneId, async, action)
        {
        }

        public override void Play(Image source)
        {
            _source = source;

            //Set the imageSource
            Color color = new Color(_transitionInfo._color.r, _transitionInfo._color.g, _transitionInfo._color.b, 0);
            _source.color = color;

            //Reset position
            _source.transform.eulerAngles = Vector3.zero;
            _source.transform.localScale = Vector3.one;

            //Run Anim
            FadeIn(_action);
        }

        public void FadeIn(Action? action)
        {
            _source.gameObject.SetActive(true);
            _source.DOFade(1, _transitionInfo._totalTime / 2).SetEase(_transitionInfo._ease)
                .OnComplete(()=> {
                    _action?.Invoke();
                    TransitionScreenManager.Instance.LoadSceneAsync(_sceneId);
                }).Play();
        }

        public void FadeOut(Action? action = null)
        {
            action?.Invoke();
            _source.DOFade(0, _transitionInfo._totalTime / 2).OnComplete(()=> {
                action?.Invoke();
                _source.gameObject.SetActive(false);
            }).Play();
        }
    }
}
