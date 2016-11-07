using UnityEngine;
using System.Collections;

public class VehicleDriver : MonoBehaviour
{
    [SerializeField] Transform _transform;

    private Vector3 initalPosition;
    private Quaternion initialRotation;
    private HingeJoint tempHinge;

    public delegate void FallEvent();

    public event FallEvent OnFallEvent;


    void Awake()
    {
        initalPosition = _transform.localPosition;
        initialRotation = _transform.localRotation;
    }


    public IEnumerator Reset(Rigidbody motorbikeBody)
    {
        EnablePhysics(false);
        ResetTransform();
        yield return new WaitForFixedUpdate();
//        this.gameObject.AddComponent<Rigidbody>();
//        this.GetComponent<Rigidbody>().mass = 60;
//        this.GetComponent<Rigidbody>().angularDrag = 0;
//        this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationY;
        CreateJoint(motorbikeBody);
        EnablePhysics(true);
        yield break;
    }

    private void ResetTransform()
    {
        _transform.localPosition = initalPosition;
        _transform.localRotation = initialRotation;
    }

    private void EnablePhysics(bool value)
    {
        this.GetComponent<Rigidbody>().isKinematic = !value;
        this.GetComponent<BoxCollider>().enabled = value;
    }


    private void CreateJoint(Rigidbody motorbikeBody)
    {
        tempHinge = this.gameObject.AddComponent<HingeJoint>();
          
        tempHinge.autoConfigureConnectedAnchor = true;
        tempHinge.anchor = new Vector3(0, 0.7f, -0.25f);

        JointSpring hingeSpring = tempHinge.spring;       
        hingeSpring.spring = 100;
        hingeSpring.damper = 100;

        tempHinge.spring = hingeSpring;
        tempHinge.useSpring = true;

        JointLimits hingeLimits = tempHinge.limits;
        hingeLimits.min = -5;
        hingeLimits.max = 5;

        tempHinge.limits = hingeLimits;
        tempHinge.useLimits = true;

        tempHinge.breakForce = 45000;
        tempHinge.breakTorque = 45000;

        tempHinge.enableCollision = false;
        tempHinge.enablePreprocessing = false;

        tempHinge.connectedBody = motorbikeBody;
    }

    void OnJointBreak(float breakForce)
    {
        if (OnFallEvent != null)
            OnFallEvent();
    }
}
