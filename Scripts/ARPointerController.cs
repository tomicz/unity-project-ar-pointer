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
        [SerializeField] private GameObject _prefabObject = null;
        [SerializeField] private float _trackingLostOffset = 0.5f;

        [Space(10)]
        public UnityEvent OnTrackableFoundEvent;
        public UnityEvent OnTrackableLostEvent;

        private ARRaycastManager _raycastManager;
        private ARSessionOrigin _sessionOrigin;
        private ARRaycaster _raycaster;
        private ARObject _arObject;
        private bool IsPrefabAvailable => _prefabObject != null;

        private void Awake()
        {
            _raycastManager = GetComponent<ARRaycastManager>();
            _sessionOrigin = GetComponent<ARSessionOrigin>();
            _raycaster = new ARRaycaster(_raycastManager, _sessionOrigin);

            if (IsPrefabAvailable)
            {
                _arObject = _prefabObject.AddComponent<ARObject>();
                _arObject.SetPointerController(this);
            }
        }

        private void Update()
        {
            if (!IsPrefabAvailable)
            {
                return;
            }

            RegisterTrackableEvents();
            UpdateIndicator();
        }

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

        public void PlaceObject()
        {
            if (!IsPrefabAvailable)
            {
                return;
            }

            if (!_raycaster.IsTrackableBeingHit)
            {
                return;
            }

            AttachAnchor(_prefabObject.transform);
            SetIndicatorNull();
        }

        public void SelectObject(GameObject gameObject)
        {
            if(!IsPrefabAvailable)
            {
                _prefabObject = gameObject;

                AttachARObject();
            }
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

        private void UpdateIndicator()
        {
            _arObject.SetPosition(_raycaster.GetRaycastHitPosition(_trackableTypes, _trackingLostOffset));
        }

        private void EnableIndicator(bool enabled) => _prefabObject.gameObject.SetActive(enabled);

        private void SetIndicatorNull()
        {
            _arObject.SetPointerController(this);
            _arObject = null;
            _prefabObject = null;
        }

        private void AttachAnchor(Transform transform)
        {
            var anchor = transform.GetComponent<ARAnchor>();

            if (anchor == null)
            {
                transform.gameObject.AddComponent<ARAnchor>();
            }
        }

        private void AttachARObject()
        {
            _arObject = gameObject.GetComponent<ARObject>();

            if (_arObject == null)
            {
                _arObject = gameObject.AddComponent<ARObject>();
            }
        }
    }
}