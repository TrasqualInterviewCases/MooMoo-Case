using UnityEngine;

namespace Main.Utilities
{
    public class LookAtCamera : MonoBehaviour
    {
        Transform cam;

        private void Awake()
        {
            cam = Camera.main.transform;
        }

        private void Update()
        {
            transform.rotation = Quaternion.LookRotation(transform.position - cam.position);
        }
    }
}