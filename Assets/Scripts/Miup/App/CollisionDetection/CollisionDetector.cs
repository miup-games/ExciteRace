using UnityEngine;
using System.Collections;
using System;

public class CollisionDetector : MonoBehaviour
{
    private bool trackCollisions = false;

    private int lastCollisionGroupID;
    private Transform rayOrigin;
    Action<TrackItem> onCollisionCB;

    public void StartTracking(Transform origin, Action<TrackItem> cb)
    {
        trackCollisions = true;
        rayOrigin = origin;
        onCollisionCB = cb;
    }

    void Update()
    {
        if (!trackCollisions)
            return;

        RaycastHit hit;
                        
        if (Physics.Raycast(rayOrigin.position, Vector3.down, out hit, 10))
        {            
            if (hit.transform.gameObject.layer != 10)
            {     
                TrackItem groupElement = hit.collider.GetComponent<TrackItem>();
                if (groupElement == null)
                {
                    return;
                }

                if (onCollisionCB != null)
                {
                    onCollisionCB(groupElement);
                }
              
            }
        }
            
    }
}
