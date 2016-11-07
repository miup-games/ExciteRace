using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class AcelerateButton :  MonoBehaviour, IPointerDownHandler,IPointerUpHandler
{
    [SerializeField] InputController _inputController;

    public void OnPointerDown(PointerEventData eventData)
    {
        _inputController.AceleratePressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _inputController.AceleratePressed = false;
    }

}
