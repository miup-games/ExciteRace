
using Miup.Vehicle.App;
using UnityEngine;

public abstract class BaseController : MonoBehaviour
{
    [SerializeField] protected VehicleMovementController _vehicle;
  
    protected bool isPlayer = false;
    protected bool controlEnabled = false;

    public bool ControlEnabled
    {
        get
        {
            return this.controlEnabled;
        }
        set
        {
            controlEnabled = value;
        }
    }

    public float VehicleGlobalZPosition
    {
        get
        {
            return this._vehicle.GlobalZPosition;
        }
    }

    public bool IsPlayer
    {
        get
        {
            return this.isPlayer;
        }       
    }
}
