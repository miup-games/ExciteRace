using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class PositionView : MonoBehaviour
{
    [SerializeField] Text _value;

    void Awake()
    {
        if (_value == null)
        {
            throw new System.ArgumentException("TimeValue cannot be null");
        }

    }

    public void UpdateView(int place)
    {
        _value.text = place.ToString();
    }
}
