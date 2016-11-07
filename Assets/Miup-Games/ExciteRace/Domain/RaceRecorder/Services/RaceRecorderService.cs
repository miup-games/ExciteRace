using System;
using LitJson;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class RaceRecorderService :IRaceRecorderService
{
    private IRaceRecorderRepo _interactionRecorderRepo;

    public RaceRecorderService(IRaceRecorderRepo interactionRecorderRepo)
    {       
        if (interactionRecorderRepo == null)
        {
            throw new ArgumentNullException("interactionRecorderRepo is null");
        }

        this._interactionRecorderRepo = interactionRecorderRepo;
    }

    public void CreateEvent(double time, Vector3 position, bool acelerate)
    {
        RaceEventModel interactionEventModel = new RaceEventModel();

        interactionEventModel.Time = time;
        interactionEventModel.Acelerate = acelerate;
        interactionEventModel.X = position.x;
        interactionEventModel.Z = position.z;

        this._interactionRecorderRepo.CreateEvent(interactionEventModel);
    }

    public void SaveEvents()
    {
        UnityEngine.Debug.LogError(">>>>>>> CreateJsonFromEvents");
        List<RaceEventModel> raceEvents = this._interactionRecorderRepo.RaceEvents;
        RaceEventsGroupModel raceEventsGroup = new RaceEventsGroupModel();   
        raceEventsGroup.RaceEvents = raceEvents;

        JsonData test = JsonMapper.ToJson(raceEventsGroup);             
        File.WriteAllText(Application.dataPath + "/MyRaceTest.json", test.ToString());
    }
}
