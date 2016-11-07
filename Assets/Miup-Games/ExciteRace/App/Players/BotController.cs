using UnityEngine;
using System.Collections;
using Miup.Vehicle.App;

public class BotController : BaseController
{
    [SerializeField] CollisionDetector _collisionDetector;

    private bool acelerating = false;
    private bool finished = false;
    private int lastCollisionGroupID;

    void Awake()
    {   
        if (_vehicle == null)
        {
            throw new System.ArgumentException("Vehicle cannot be null");
        }

        if (_collisionDetector == null)
        {
            throw new System.ArgumentException("CollisionDetector cannot be null");
        }

        isPlayer = false;

        _collisionDetector.StartTracking(_vehicle.CollisionDetectorTransform, OnCollision);

    }

    void Update()
    {
        if (!ControlEnabled || finished)
            return;

        if (acelerating)
            _vehicle.SpeedUp();
        else
            _vehicle.SpeedDown();                   

        acelerating = true;
	
    }

    void OnCollision(TrackItem groupElement)
    {
        int currentCollisionGroupID = groupElement.GroupId;

        if (groupElement.ItemType != TrackItemType.OBSTACLE)
        {
            if (_vehicle.Vehicle.Speed > 100)
                acelerating = false;
        }
            
        if (lastCollisionGroupID == currentCollisionGroupID)
            return;

        lastCollisionGroupID = currentCollisionGroupID;

        if (groupElement.ItemType == TrackItemType.OBSTACLE)
        {                    
            _vehicle.HandleChangeLine();
        }    


        if (groupElement.ItemType == TrackItemType.FINISH_LINE)
        {
            acelerating = false;
            finished = true;
        }
        
    }
}
