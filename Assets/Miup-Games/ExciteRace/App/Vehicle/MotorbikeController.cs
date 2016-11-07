using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MotorbikeController : VehicleController
{
    [SerializeField] WheelCollider _frontWheel;
    [SerializeField] WheelCollider _rearWheel;
    [SerializeField] AudioSource _motorSFX;
    [SerializeField] int _pitchDivider;
    [SerializeField] float _speedMultiplier = 7.5f;

    private bool restarting = false;

    void Start()
    {        
        _rigidbody.centerOfMass = _centerOfGravity.localPosition;
        _vehicleDriver.OnFallEvent += OnFallEvent;
        SpeedDown();
    }

    void OnFallEvent()
    {        
        SpeedDown();
        restarting = true;
        StartCoroutine(Reset());
    }

    IEnumerator Reset()
    {     
        yield return new WaitForSeconds(1);    
        this.GetComponent<Rigidbody>().isKinematic = true;
        this._vehicleTransform.localPosition = new Vector3(0, 0, this._vehicleTransform.localPosition.z - 20);
        yield return StartCoroutine(this._vehicleDriver.Reset(_rigidbody)); 
        this.GetComponent<Rigidbody>().isKinematic = false;
        restarting = false;
    }

    void FixedUpdate()
    {   
        SetMotorPitch();

        float scaledTorque = _torque;

        if (_rearWheel.rpm < _idealRPM)
            scaledTorque = Mathf.Lerp(scaledTorque / 10f, scaledTorque, _rearWheel.rpm / _idealRPM);
        else
            scaledTorque = Mathf.Lerp(scaledTorque, 0, (_rearWheel.rpm - _idealRPM) / (_maxRPM - _idealRPM));

        _rearWheel.motorTorque = scaledTorque;         

    }

    private void SetMotorPitch()
    {
        if (_motorSFX == null)
            return;
        
        float pitch = _rigidbody.velocity.z / _pitchDivider;

        if (pitch > 3)
        {
            pitch = 3;
        }
        else if (pitch < 0.1f)
        {
            pitch = 0.1f;
        }
       
        _motorSFX.pitch = pitch;
    }

    override public int Speed
    {
        get
        {
            return   Mathf.FloorToInt(_rigidbody.velocity.z * _speedMultiplier);
        }
    }

    override public float Rpm
    {
        get
        {
            return _rearWheel.rpm;
        }
    }

    override public void SpeedUp()
    {       
        if (!restarting)
            StopBraking();
    }

    override public void SpeedDown()
    {   
        if (!restarting)
            StartBraking();
    }


    override public void StartBraking()
    {        
        _frontWheel.brakeTorque = _brakeTorque;
        _rearWheel.brakeTorque = _brakeTorque;
    }

    override public void StopBraking()
    {                     
        _frontWheel.brakeTorque = 0;
        _rearWheel.brakeTorque = 0;
    }

}
