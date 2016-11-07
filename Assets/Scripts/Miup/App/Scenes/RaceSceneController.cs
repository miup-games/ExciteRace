using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class RaceSceneController : MonoBehaviour
{
    [SerializeField] CountDownController _countdownController;
    [SerializeField] TimeController _timeController;
    [SerializeField] PositionController _positionController;
    [SerializeField] List<BaseController> _racersControllers;

    void Awake()
    {   
        if (_countdownController == null)
        {
            throw new System.ArgumentException("CountDownController cannot be null");
        }

        if (_timeController == null)
        {
            throw new System.ArgumentException("TimeController cannot be null");
        }


        if (_positionController == null)
        {
            throw new System.ArgumentException("PositionController cannot be null");
        }
    }

    void Start()
    {
        EnableInput(false);
        Application.targetFrameRate = 30;     
        _countdownController.Init(OnCountDownFinished);
    }

    public void RestartRace()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnCountDownFinished()
    {
        EnableInput(true);
        _timeController.Init();
        _positionController.Init();
    }

    private void EnableInput(bool value)
    {
        int racersCount = _racersControllers.Count;
        for (int i = 0; i < racersCount; i++)
        {
            _racersControllers[i].ControlEnabled = value;
        }
    }

	
}
