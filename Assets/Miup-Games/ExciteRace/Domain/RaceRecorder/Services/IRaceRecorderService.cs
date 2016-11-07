using UnityEngine;


public interface IRaceRecorderService
{
    void CreateEvent(double time, Vector3 position, bool acelerate);

    void SaveEvents();
}
