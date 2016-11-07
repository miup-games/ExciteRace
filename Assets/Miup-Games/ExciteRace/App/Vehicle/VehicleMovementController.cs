using UnityEngine;
using System.Collections;
using Zenject;

namespace Miup.Vehicle.App
{
    public class VehicleMovementController : MonoBehaviour
    {
        [SerializeField] VehicleController _vehicle;
        private bool topTrack;

        public VehicleController Vehicle
        {
            get
            {
                return this._vehicle;   
            }
        }

        public float GlobalZPosition
        {
            get
            {
                return _vehicle.GlobalZPosition;
            }
        }

        public Transform CollisionDetectorTransform
        {
            get{ return _vehicle.CollisionDetectorTransform; }
        }

        void Awake()
        {
            if (_vehicle.VehicleTransform.localPosition.x == TrackConstants.TOP_TRACK)
                topTrack = true;
        }

        public void HandleChangeLine()
        {                       
            if (!topTrack)
            {                      
                _vehicle.MoveToTopTrack(); 
                topTrack = true;
            }
            else
            {             
                _vehicle.MoveToBottomTrack();
                topTrack = false;
            }                
        }

        public void SpeedUp()
        {         
            _vehicle.SpeedUp();        
        }

        public void SpeedDown()
        {            
            _vehicle.SpeedDown();
        }

    }
}
