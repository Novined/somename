using UnityEngine;

namespace Assets
{
    class GroundBlock : MonoBehaviour
    {
        public bool allowDownShift = true;

        private Collider2D _collider;

        void Start()
        {
            _collider = GetComponent<Collider2D>();
            _collider.isTrigger = true;
        }

        /*void OnTriggerExit(Collider col)
        {
            Debug.Log("Exit");
        }

        void OnTriggerEnter(Collider col)
        {
            Debug.Log("Enter");
        }*/
    }
}
