using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public abstract class VehicleController : MonoBehaviour
{
    [SerializeField] protected Transform _vehicleTransform;
    [SerializeField] protected VehicleDriver _vehicleDriver;
    [SerializeField] protected Transform _centerOfGravity;
    [SerializeField] protected Transform _rayTransform;
    [SerializeField] protected Rigidbody _rigidbody;

    [SerializeField] protected float _idealRPM = 500f;
    [SerializeField] protected float _maxRPM = 1000f;
    [SerializeField] protected float _torque = 25f;
    [SerializeField] protected float _brakeTorque = 100f;

    abstract public int Speed{ get; }

    abstract public float Rpm{ get; }

    abstract public void SpeedUp();

    abstract public void SpeedDown();

    abstract public void StartBraking();

    abstract public void StopBraking();

    virtual public Transform VehicleTransform
    {
        get { return _vehicleTransform; }
    }

    virtual public Transform CollisionDetectorTransform
    {
        get{ return this._rayTransform; }
    }

    virtual public float GlobalZPosition
    {
        get { return _vehicleTransform.position.z; }
    }

    virtual public Vector3 CurrentPosition
    {
        get { return _vehicleTransform.localPosition; }
    }

    virtual public void MoveTo(Vector3 targetPosition)
    {
        _vehicleTransform.localPosition = targetPosition;
    }

    virtual public void MoveToTopTrack()
    {            
        Vector3 position = new Vector3(TrackConstants.TOP_TRACK, CurrentPosition.y, CurrentPosition.z);
        MoveTo(position);
     
    }

    virtual public void MoveToBottomTrack()
    {            
        Vector3 position = new Vector3(TrackConstants.BOTTOM_TRACK, CurrentPosition.y, CurrentPosition.z);
        MoveTo(position);
     
    }

}
