using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace PROTransition { 
    public class SquareFilledTransition : Transition
    {
        private Image _transitionImage;

        public SquareFilledTransition(TransitionInfo transitionInfo, int sceneId, bool async, Action action = null) : base(transitionInfo, sceneId, async, action)
        {
        }

        public override void Play(List<GameObject> sources)
        {
            _transitionImage = sources[0].GetComponent<Image>();

            //Set the imageSource
            _transitionImage.color = _transitionInfo._color;

            _transitionImage.gameObject.SetActive(true);

            switch (_transitionInfo._origin)
            {
                case TransitionOrigin.Right:
                    _transitionImage.fillMethod = Image.FillMethod.Horizontal;
                    _transitionImage.fillOrigin = 1;
                    break;
                case TransitionOrigin.Left:
                    _transitionImage.fillMethod = Image.FillMethod.Horizontal;
                    _transitionImage.fillOrigin = 3;

                    break;
                case TransitionOrigin.Up:
                    _transitionImage.fillMethod = Image.FillMethod.Vertical;
                    _transitionImage.fillOrigin = 1;
                    break;
                case TransitionOrigin.Down:
                    _transitionImage.fillMethod = Image.FillMethod.Vertical;
                    _transitionImage.fillOrigin = 2;
                    break;
            }


            //Run Anim
            DOVirtual.Float(0f, 1f,_transitionInfo._totalTime/2, (value) =>
            {
                _transitionImage.fillAmount = value;
            })
            .SetEase(_transitionInfo._ease)
            .OnComplete(() => {
                _action?.Invoke();
                PROTransitionManager.Instance.LoadSceneAsync(_sceneId);
            })
            .Play();
        }

        public override void Restart(Action? action= null)
        {
            action?.Invoke();
            DOVirtual.Float(1f, 0f, _transitionInfo._totalTime / 2, (value) =>
            {
                _transitionImage.fillAmount = value;
            })
            .SetEase(_transitionInfo._ease)
            .OnComplete(() => {
                _transitionImage.gameObject.SetActive(false);
                PROTransitionManager.Instance.SetCurrentTransition(null);
            })
            .Play();
        }

        
    }

}
