using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIButtonSounds : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        Managers.AudioController.PlayHoverSound();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Managers.AudioController.PlayClickSound();
    }

}
