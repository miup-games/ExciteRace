using UnityEngine;
using LitJson;
using System.Collections.Generic;

namespace Miup.Simulation.RaceSimulation
{
    [CreateAssetMenu] 
    public class RaceSimulationJsonReader : ScriptableObject
    {
        public TextAsset RaceJson;
        public float ErrorMargin;

        private List<RaceEventModel> raceEvents;

        public void LoadRaceJson()
        {
            RaceEventsGroupModel raceEventsGroupModel = JsonMapper.ToObject<RaceEventsGroupModel>(RaceJson.text);                         
            raceEvents = raceEventsGroupModel.RaceEvents;
        }

        public RaceEventModel GetRaceEventByTime(float elapsedTime)
        {
            int raceEventsCount = raceEvents.Count;
            RaceEventModel raceEvent = null;

            for (int i = 0; i < raceEventsCount; i++)
            {                                
                if (((elapsedTime - ErrorMargin) <= raceEvents[i].Time)
                    && (raceEvents[i].Time <= (elapsedTime + ErrorMargin)))
                {
                    raceEvent = raceEvents[i];
                    raceEvents.RemoveAt(i);
                    break;
                }
                else if (elapsedTime < raceEvents[i].Time)
                {                    
                    break;
                }  
            }

            return raceEvent;
        }

      
    }
}