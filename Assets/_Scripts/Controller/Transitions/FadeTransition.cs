using DG.Tweening;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PROTransition
{
    public class FadeTransition : Transition
    {
        private Image _fadeImage;

        public FadeTransition(TransitionInfo transitionInfo, int sceneId, bool async, Action action = null) : base(transitionInfo, sceneId, async, action)
        {
        }

        public override void Play(List<GameObject> sources)
        {
            _fadeImage = sources[0].GetComponent<Image>();

            //Set the imageSource
            Color color = new Color(_transitionInfo._color.r, _transitionInfo._color.g, _transitionInfo._color.b, 0);
            _fadeImage.color = color;

            //Reset position
            _fadeImage.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
            _fadeImage.transform.eulerAngles = Vector3.zero;
            _fadeImage.transform.localScale = Vector3.one;

            //Run Anim
            FadeIn(_action);
        }

        public override void Restart(Action? action= null)
        {
            action?.Invoke();
            _fadeImage.DOFade(0, _transitionInfo._totalTime / 2).OnComplete(() => {
                _fadeImage.gameObject.SetActive(false);
                PROTransitionManager.Instance.SetCurrentTransition(null);
            }).Play();
        }

        public void FadeIn(Action? action)
        {
            _fadeImage.gameObject.SetActive(true);
            _fadeImage.DOFade(1, _transitionInfo._totalTime / 2).SetEase(_transitionInfo._ease)
                .OnComplete(()=> {
                    _action?.Invoke();
                    PROTransitionManager.Instance.LoadSceneAsync(_sceneId);
                }).Play();
        }
    }
}
