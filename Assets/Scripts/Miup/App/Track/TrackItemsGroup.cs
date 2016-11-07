using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TrackItemsGroup : MonoBehaviour
{
    [SerializeField] List<TrackItem> _groupElements;
    [SerializeField] string _groupName;
    [SerializeField] TrackItemType _groupType;
    [SerializeField] float _recomendedSpeed;


    void Awake()
    {
        int count = _groupElements.Count;

        for (int i = 0; i < count; i++)
        {
            TrackItem groupElement = _groupElements[i];

            groupElement.GroupName = _groupName;        
            groupElement.ItemType = _groupType;
            groupElement.RecomendedSpeed = _recomendedSpeed;
            groupElement.GroupId = this.GetInstanceID();
        }
    }
	

}
