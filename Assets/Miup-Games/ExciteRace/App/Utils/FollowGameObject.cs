using UnityEngine;
using System.Collections;

namespace Miup.Vehicle.App.Utils
{
    public class FollowGameObject : MonoBehaviour
    {
        [SerializeField] GameObject _follower;
        [SerializeField] GameObject _target;
        [SerializeField] bool _followX;
        [SerializeField] bool _followY;
        [SerializeField] bool _followZ;
  
        private Vector3 initialPosition;
        private Vector3 offset;

        void Start()
        {         
            initialPosition = _follower.transform.position;
            offset = initialPosition - _target.transform.position;
        }

        // LateUpdate is called after Update each frame
        void LateUpdate()
        {         
            Vector3 newPos = initialPosition;

            if (_followX)
            {
                newPos.x = _target.transform.position.x + offset.x;
            }

            if (_followY)
            {
                newPos.y = _target.transform.position.y + offset.y;
            }

            if (_followZ)
            {
                newPos.z = _target.transform.position.z + offset.z;
            }

            _follower.transform.position = newPos;
        }
    }
}