using System.Collections;
using UnityEngine;

namespace Assets.MyAssets.Scripts
{
    public class CameraFollowScript : MonoBehaviour
    {

        [SerializeField] GameObject _playerCarObject;
        public Vector3 _cameraOffset;
        public Vector3 _targetedPosition;
        public Vector3 _velocity = Vector3.zero;
        public float _smoothTime =0.1f;

        private void Start()
        {
            transform.rotation = Quaternion.Euler(0,0,0);
            _cameraOffset = new Vector3(0,1.8f, -8);
        }
        private void LateUpdate()
        {
            _targetedPosition = _playerCarObject.transform.position + _cameraOffset;
            transform.position = Vector3.SmoothDamp(transform.position, _targetedPosition, ref _velocity, _smoothTime);
        }


    }
}