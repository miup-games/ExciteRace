using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class TimeView : MonoBehaviour
{
    [SerializeField] Text _value;

    void Awake()
    {
        if (_value == null)
        {
            throw new System.ArgumentException("TimeValue cannot be null");
        }

    }

    public void UpdateView(TimeSpan elapsedTime)
    {
        _value.text = String.Format("{0:00}:{1:00}:{2:000}", elapsedTime.Minutes, elapsedTime.Seconds, elapsedTime.Milliseconds);       
    }
}
