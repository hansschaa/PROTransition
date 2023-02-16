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
        Rect maskButtoon = new Rect(10, 80, 200, 50);

        if (GUI.Button(fadeButtoon, "Fade animation"))
        {
            var nextScene = SceneManager.GetActiveScene().buildIndex == 0 ? 1 : 0;

            PROTransitionManager.Instance.Play(new FadeTransition
                (new TransitionInfo(Color.white, 2, DG.Tweening.Ease.Linear, TransitionType.Fade, TransitionOrigin.Center), 
                nextScene , true, () => print("<color=yellow>End Fade In</color>")));
        }

        else if (GUI.Button(maskButtoon, "Mask animation"))
        {
            var nextScene = SceneManager.GetActiveScene().buildIndex == 0 ? 1 : 0;

            PROTransitionManager.Instance.Play(new MaskTransition
                (new TransitionInfo(Color.white, 2, DG.Tweening.Ease.Linear, TransitionType.Mask, TransitionOrigin.Center),
                nextScene, true, () => print("<color=yellow>End Mask In</color>")));
        }
    }
}
