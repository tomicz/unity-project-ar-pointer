using UnityEngine;

namespace TOMICZ.AR
{
    public class ARObject : MonoBehaviour
    {
        private ARPointerController _pointerController;

        /// <summary>
        /// Sets a reference to ARPointerController.
        /// </summary>
        /// <param name="pointerController"></param>
        public void SetPointerController(ARPointerController pointerController) => _pointerController = pointerController;

        /// <summary>
        /// Changes world position of an object.
        /// </summary>
        /// <param name="position"></param>
        public void SetPosition(Vector3 position) => transform.position = position;

        private void OnMouseUp()
        {
            _pointerController.SelectObject(gameObject);
        }
    }
}