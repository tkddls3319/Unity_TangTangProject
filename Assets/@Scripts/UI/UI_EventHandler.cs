using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_EventHandler : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerMoveHandler, IPointerEnterHandler, IPointerExitHandler
{
    public event Action OnClickHandler = null;
    public event Action OnDownHandler = null;
    public event Action OnMoveHandler = null;
    public event Action OnEnterHandler = null;
    public event Action OnExitHandler = null;
    public void OnPointerClick(PointerEventData eventData)
    {
        OnClickHandler?.Invoke();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        OnDownHandler?.Invoke();
    }
    public void OnPointerMove(PointerEventData eventData)
    {
        OnMoveHandler?.Invoke();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        OnEnterHandler?.Invoke();
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        OnExitHandler?.Invoke();
    }
}
