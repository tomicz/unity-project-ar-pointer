using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

namespace TOMICZ.AR
{
    public class ARRaycaster
    {
        public bool IsTrackableBeingHit => _isTrackableFound;

        private ARRaycastManager _raycastManager;
        private ARSessionOrigin _sessionOrigin;
        private List<ARRaycastHit> _raycastHits;
        private Vector2 _screenPoint;
        private bool _isTrackableFound;

        /// <summary>
        /// ARRaycaster is a raycast that detects only AR Trackables.
        /// </summary>
        /// <param name="raycastManager"></param>
        /// <param name="sessionOrigin"></param>
        public ARRaycaster(ARRaycastManager raycastManager, ARSessionOrigin sessionOrigin)
        {
            _raycastManager = raycastManager;
            _sessionOrigin = sessionOrigin;
            _screenPoint = new Vector2(Screen.width / 2, Screen.height / 2);
        }

        /// <summary>
        /// Gets position where raycast and trackable intersect.
        /// </summary>
        /// <param name="trackableTypes"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public Vector3 GetRaycastHitPosition(TrackableType trackableTypes, float offset)
        {
            if (IsTrackableFound(trackableTypes))
            {
                if (_raycastHits.Count > 0)
                {
                    return _raycastHits[0].pose.position;
                }
            }

            return _sessionOrigin.camera.transform.position + _sessionOrigin.camera.transform.forward * offset;
        }

        private bool IsTrackableFound(TrackableType trackableTypes)
        {
            _raycastHits = new List<ARRaycastHit>();
            _isTrackableFound = _raycastManager.Raycast(_screenPoint, _raycastHits, trackableTypes);

            return _isTrackableFound;
        }
    }
}