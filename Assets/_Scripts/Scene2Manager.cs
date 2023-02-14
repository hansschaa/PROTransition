using UnityEngine;
using PROTransition;

public class Scene2Manager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TransitionScreenManager.Instance.Restart(()=> print("Begin restart"));
    }
}
