using UnityEngine;
using System.Collections;
using System.Diagnostics;
using Miup.Vehicle.App;
using UnityEngine.EventSystems;

public class InputController : MonoBehaviour
{
    [SerializeField] PlayerController _playerController;
    private bool changeTrackPressed;
    private bool aceleratePressed;

    [SerializeField] AudioSource _changeTrack;

    void Awake()
    {        
        if (_playerController == null)
        {
            throw new System.ArgumentException("PlayerController cannot be null");
        }
    }
 
    // Behaviour messages
    void Update()
    {
                   
        if (Input.GetKeyDown(KeyCode.Space) || changeTrackPressed)
        {
            _playerController.HandleChangeLine();

            if (_changeTrack != null)
            {
                _changeTrack.Play();
            }

            ChangeTrackPressed = false;
        }
            

        if (Input.GetKeyDown(KeyCode.UpArrow) || aceleratePressed)
        {
            _playerController.SpeedUp();
        }

        if (Input.GetKeyUp(KeyCode.UpArrow) || !aceleratePressed)
        {
            _playerController.SpeedDown();
        }
    }

    public bool ChangeTrackPressed
    {
        set
        {
            changeTrackPressed = value;
        }
    }

    public bool AceleratePressed
    {
        set
        {
            aceleratePressed = value;
        }
    }

}
