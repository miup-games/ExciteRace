using UnityEngine;
using Miup.Simulation.RaceSimulation;
using Miup.Vehicle.App;


public class SimulationController: MonoBehaviour
{
    [SerializeField] RaceSimulationJsonReader _raceSimulationJsonReader;
    [SerializeField] TimeController _timeController;
    [SerializeField] VehicleMovementController _vehicleTrackMovementController;

    bool acelerating = false;

    void Awake()
    {
        _raceSimulationJsonReader.LoadRaceJson();
    }

    void Update()
    {
        RaceEventModel raceEvent = _raceSimulationJsonReader.GetRaceEventByTime(_timeController.ElapsedRaceTime);
        
        if (raceEvent != null)
        {            
            acelerating = raceEvent.Acelerate;
//            _vehicleTrackMovementController.MoveToPosition(raceEvent.X);
        }

        if (acelerating)
            _vehicleTrackMovementController.SpeedUp();
        else
            _vehicleTrackMovementController.SpeedDown();
    }
}

