using UnityEngine;

namespace TOMICZ.AR
{
    public class ARObject : MonoBehaviour
    {
        private ARPointerController _pointerController;

        public void SetPointerController(ARPointerController pointerController) => _pointerController = pointerController;

        public void SetPosition(Vector3 position) => transform.position = position;

        private void OnMouseUp()
        {
            _pointerController.SelectObject(gameObject);
        }
    }
}