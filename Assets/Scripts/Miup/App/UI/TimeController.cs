using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using System.Linq;

public class TimeController : MonoBehaviour
{
    [SerializeField] TimeView _timeView;

    private float elapsedRaceTime;
    private bool raceStarted;

    public void Init()
    {
        raceStarted = true;
    }

    void Update()
    {      
        if (!raceStarted)
            return;
        
        elapsedRaceTime += Time.deltaTime;
        TimeSpan span = System.TimeSpan.FromSeconds(elapsedRaceTime);
        _timeView.UpdateView(span);    
    }

    public float ElapsedRaceTime
    {
        get
        {
            return this.elapsedRaceTime;
        }
    }
}
