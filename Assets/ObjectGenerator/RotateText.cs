using TMPro;
using UnityEngine;

namespace Assets
{
    public class RotateText : MonoBehaviour
    {
        private bool _rotate;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        public void StartRotation(string text)
        {
            this.gameObject.GetComponent<MeshRenderer>().enabled = true;
            this.GetComponent<TextMeshPro>().SetText(text);
            _rotate = true;
        }

        public void StopRotation()
        {
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
            _rotate = false;
        }

        // Update is called once per frame
        void Update()
        {
            if(_rotate)
                this.transform.Rotate(0f, 0.5f, 0f);
        }
    }
}
