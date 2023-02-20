using PROTransition;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Demo : MonoBehaviour
{
    void Start()
    {
        //This is usefull for restart the transition animation
        PROTransitionManager.Instance.Restart(() => print("Begin restart"));
    }

    void OnGUI()
    {
        // Define la posición y el tamaño del botón
        Rect fadeButtoon = new Rect(10, 10, 200, 50);
        // Define la posición y el tamaño del botón
        Rect filledRightButtoon = new Rect(10, 80, 200, 50);
        Rect filledLeftButtoon = new Rect(10, 150, 200, 50);
        Rect filledUpButtoon = new Rect(10, 220, 200, 50);
        Rect filledDownButtoon = new Rect(10, 290, 200, 50);
        // Define la posición y el tamaño del botón
        Rect maskButtoon = new Rect(10, 360, 200, 50);

        if (GUI.Button(fadeButtoon, "Fade animation"))
        {
            var nextScene = SceneManager.GetActiveScene().buildIndex == 0 ? 1 : 0;

            PROTransitionManager.Instance.Play(new FadeTransition
                (new TransitionInfo(Color.black, 2, DG.Tweening.Ease.Linear, TransitionType.Fade, null), 
                nextScene , true, () => print("<color=yellow>End Fade In</color>")));
        }

        else if (GUI.Button(filledRightButtoon, "Right Horizontal animation"))
        {
            var nextScene = SceneManager.GetActiveScene().buildIndex == 0 ? 1 : 0;

            PROTransitionManager.Instance.Play(new SquareFilledTransition
                (new TransitionInfo(Color.black, 2, DG.Tweening.Ease.Linear, TransitionType.Filled, TransitionOrigin.Right),
                nextScene, true, () => print("<color=yellow>End Horizontal trasnition</color>")));
        }

        else if (GUI.Button(filledLeftButtoon, "Left Horizontal animation"))
        {
            var nextScene = SceneManager.GetActiveScene().buildIndex == 0 ? 1 : 0;

            PROTransitionManager.Instance.Play(new SquareFilledTransition
                (new TransitionInfo(Color.black, 2, DG.Tweening.Ease.Linear, TransitionType.Filled, TransitionOrigin.Left),
                nextScene, true, () => print("<color=yellow>End Horizontal trasnition</color>")));
        }

        else if (GUI.Button(filledUpButtoon, "Up Horizontal animation"))
        {
            var nextScene = SceneManager.GetActiveScene().buildIndex == 0 ? 1 : 0;

            PROTransitionManager.Instance.Play(new SquareFilledTransition
                (new TransitionInfo(Color.black, 2, DG.Tweening.Ease.Linear, TransitionType.Filled, TransitionOrigin.Up),
                nextScene, true, () => print("<color=yellow>End Horizontal trasnition</color>")));
        }

        else if (GUI.Button(filledDownButtoon, "Down Horizontal animation"))
        {
            var nextScene = SceneManager.GetActiveScene().buildIndex == 0 ? 1 : 0;

            PROTransitionManager.Instance.Play(new SquareFilledTransition
                (new TransitionInfo(Color.black, 2, DG.Tweening.Ease.Linear, TransitionType.Filled, TransitionOrigin.Down),
                nextScene, true, () => print("<color=yellow>End Horizontal trasnition</color>")));
        }

        else if (GUI.Button(maskButtoon, "Mask animation"))
        {
            var nextScene = SceneManager.GetActiveScene().buildIndex == 0 ? 1 : 0;

            PROTransitionManager.Instance.Play(new MaskTransition
                (new TransitionInfo(Color.black, 2, DG.Tweening.Ease.Linear, TransitionType.Mask, null),
                nextScene, true, () => print("<color=yellow>End Mask In</color>")));
        }
    }
}
