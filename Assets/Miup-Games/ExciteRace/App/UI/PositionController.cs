using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class PositionController : MonoBehaviour
{
    [SerializeField] PositionView _positionView;
    [SerializeField] List<BaseController> _racersControllers;

    [SerializeField] AudioSource _celebration;
    [SerializeField] AudioSource _mumble;

    private int prevPosition;

    void Awake()
    {
        if (_racersControllers == null || _racersControllers.Count == 0)
        {
            throw new System.ArgumentException("RacersControllers cannot be null");
        }
    }

    void Start()
    {        
        prevPosition = CalculatePosition();
        _positionView.UpdateView(prevPosition);
    }

    public void Init()
    {
        StartCoroutine(UpdatePosition());
    }

    private IEnumerator UpdatePosition()
    {        
        while (true)
        {
            int currentPosition = CalculatePosition();
            if (currentPosition < prevPosition)
            {                
                _celebration.Play();
                _positionView.UpdateView(currentPosition);
            }
            else if (currentPosition > prevPosition)
            {
                _mumble.Play();
                _positionView.UpdateView(currentPosition);
            }
            prevPosition = currentPosition;
            yield return new WaitForSeconds(0.5f);
        }
    }

    private int CalculatePosition()
    {
        List<BaseController> list = _racersControllers.OrderByDescending(x => x.VehicleGlobalZPosition).ToList(); 
        int totalPlayers = list.Count;

        for (int placeIndex = 0; placeIndex < totalPlayers; placeIndex++)
        {
            if (list[placeIndex].IsPlayer)
            {
                return placeIndex + 1;
            }
        }

        return totalPlayers;
    }

}
