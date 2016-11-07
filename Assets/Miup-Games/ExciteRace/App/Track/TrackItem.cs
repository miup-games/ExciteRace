using UnityEngine;
using System.Collections;

public class TrackItem : MonoBehaviour
{
    int groupId;
    string groupName;
    TrackItemType itemType;
    float recomendedSpeed;

    public int GroupId
    {
        get
        {
            return this.groupId;
        }
        set
        {
            groupId = value;
        }
    }

    public string GroupName
    {
        get
        {
            return this.groupName;
        }
        set
        {
            groupName = value;
        }
    }

    public TrackItemType ItemType
    {
        get
        {
            return itemType;
        }
        set
        {
            itemType = value;
        }
    }

    public float RecomendedSpeed
    {
        get
        {
            return recomendedSpeed;
        }
        set
        {
            recomendedSpeed = value;
        }
    }
}
