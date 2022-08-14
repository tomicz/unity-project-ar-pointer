using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

namespace TOMICZ.AR
{
    [RequireComponent(typeof(ARSessionOrigin))]
    [RequireComponent(typeof(ARRaycastManager))]
    public class ARPointerController : MonoBehaviour
    {
        [SerializeField] private TrackableType _trackableTypes;
        [SerializeField] private Transform _indicatorObject = null;
        [SerializeField] private float _trackingLostOffset = 0.5f;

        [Space(10)]
        public UnityEvent OnTrackableFoundEvent;
        public UnityEvent OnTrackableLostEvent;

        private ARRaycastManager _raycastManager;
        private ARSessionOrigin _sessionOrigin;
        private ARRaycaster _raycaster;
        private bool IsIndicatorAvailable => _indicatorObject != null;

        public void EnablePointer()
        {
            enabled = true;
            EnableIndicator(enabled);
        }

        public void DisablePointer()
        {
            enabled = false;
            EnableIndicator(enabled);
        }

        private void Awake()
        {
            _raycastManager = GetComponent<ARRaycastManager>();
            _sessionOrigin = GetComponent<ARSessionOrigin>();
            _raycaster = new ARRaycaster(_raycastManager, _sessionOrigin);
        }

        private void FixedUpdate()
        {
            if (!IsIndicatorAvailable)
            {
                return;
            }

            RegisterTrackableEvents();
            UpdateIndicatorPosition();
        }

        private void RegisterTrackableEvents()
        {
            if (_raycaster.IsTrackableBeingHit)
            {
                OnTrackableFoundEvent?.Invoke();
            }
            else
            {
                OnTrackableLostEvent?.Invoke();
            }
        }

        private void UpdateIndicatorPosition()
        {
            _indicatorObject.transform.position = _raycaster.RaycastHitPosition(_trackableTypes, _trackingLostOffset);
        }

        private void EnableIndicator(bool enabled) => _indicatorObject.gameObject.SetActive(enabled);
    }
}