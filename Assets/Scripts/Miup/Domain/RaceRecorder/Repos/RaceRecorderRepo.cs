using System.Collections.Generic;


public class RaceRecorderRepo: IRaceRecorderRepo
{
    List<RaceEventModel> events;

    public RaceRecorderRepo()
    {
        events = new List<RaceEventModel>();
    }

    public void CreateEvent(RaceEventModel eventModel)
    {
        events.Add(eventModel);
    }

    public void CreateJsonFromEvents()
    {
        throw new System.NotImplementedException();
    }

    public List<RaceEventModel> RaceEvents
    {
        get
        {
            return events;
        }
    }
}
