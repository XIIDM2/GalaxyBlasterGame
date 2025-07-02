using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIButtonSounds : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        Managers.Audio.PlayHoverSound();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Managers.Audio.PlayClickSound();
    }

}
