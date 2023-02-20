using UnityEngine;

namespace PROTransition{
    public class Version : MonoBehaviour
    {
        TextMesh _textMeshVersion;

        private void Awake()
        {
            _textMeshVersion = GetComponent<TextMesh>();
        }

        // Start is called before the first frame update
        void Start()
        {
            _textMeshVersion.text = "v" + Application.version;
        }
    }

}
