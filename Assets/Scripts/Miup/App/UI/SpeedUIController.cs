using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpeedUIController : MonoBehaviour
{
    [SerializeField] Text _speedValue;
    [SerializeField] VehicleController _vehicle;

    void Awake()
    {
        if (_vehicle == null)
        {
            throw new System.ArgumentException("Vehicle cannot be null");
        } 
        if (_speedValue == null)
        {
            throw new System.ArgumentException("SpeedValue cannot be null");
        }
    }

    void Update()
    {
        UpdateSpeed(_vehicle.Speed);
    }

    private void UpdateSpeed(float speedValue)
    {                
        if (speedValue < 0)
        {
            speedValue = 0;
        }

        _speedValue.text = speedValue.ToString();
    }
}
