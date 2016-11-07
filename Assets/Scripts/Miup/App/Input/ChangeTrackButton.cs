using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ChangeTrackButton :  MonoBehaviour ,IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] InputController _inputController;

    public void OnPointerDown(PointerEventData eventData)
    {
        _inputController.ChangeTrackPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _inputController.ChangeTrackPressed = false;
    }

}
