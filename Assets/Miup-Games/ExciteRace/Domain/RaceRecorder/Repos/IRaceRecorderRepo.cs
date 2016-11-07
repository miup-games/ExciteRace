using System.Collections.Generic;


public interface IRaceRecorderRepo
{
    List<RaceEventModel> RaceEvents { get; }

    void CreateEvent(RaceEventModel eventModel);

    void CreateJsonFromEvents();
}
