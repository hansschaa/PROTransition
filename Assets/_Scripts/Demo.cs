using PROTransition;
using UnityEngine;

public class Demo : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) {
            TransitionScreenManager.Instance.Play(new FadeTransition
                (new TransitionInfo(Color.white, 2, DG.Tweening.Ease.Linear, TransitionType.Fade, TransitionOrigin.Center)
                , 1, true, () => print("End Fade In")));
        }

        else if (Input.GetKeyDown(KeyCode.S))
        {
            
        }
    }
}
