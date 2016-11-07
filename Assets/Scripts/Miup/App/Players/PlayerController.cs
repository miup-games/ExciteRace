using UnityEngine;
using System.Collections;
using Zenject;
using Miup.Vehicle.App;
using UnityEngine.SceneManagement;

public class PlayerController : BaseController
{
    [SerializeField] ChatController _chatController;
    [SerializeField] CollisionDetector _collisionDetector;

    private int lastCollisionGroupID;
    private bool finished = false;

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

        isPlayer = true;
        _collisionDetector.StartTracking(_vehicle.CollisionDetectorTransform, OnCollision);

    }

    public void HandleChangeLine()
    {        
        if (!ControlEnabled || finished)
            return;
        
        _vehicle.HandleChangeLine();
    }

    public void SpeedUp()
    {
        if (!ControlEnabled || finished)
            return;
        
        _vehicle.SpeedUp();
    }

    public void SpeedDown()
    {
        if (!ControlEnabled || finished)
            return;
        
        _vehicle.SpeedDown();
    }

    void OnCollision(TrackItem groupElement)
    {
        Debug.LogError("OnCollision");
        int currentCollisionGroupID = groupElement.GroupId;
       
        if (lastCollisionGroupID == currentCollisionGroupID)
            return;

        lastCollisionGroupID = currentCollisionGroupID;
        _chatController.CreateMessage(groupElement.GroupName);

        if (groupElement.ItemType == TrackItemType.FINISH_LINE)
        {         
            finished = true;
        }         
    }
}
