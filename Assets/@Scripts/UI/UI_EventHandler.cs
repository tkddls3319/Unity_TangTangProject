using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_EventHandler : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler, IPointerMoveHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public event Action OnClickHandler = null;
    public event Action OnPointerDownHandler = null;
    public event Action OnPointerUpHandler = null;
    public event Action OnEnterHandler = null;
    public event Action OnExitHandler = null;

    public event Action OnMoveHandler = null;
    public Action<BaseEventData> OnDragHandler = null;
    public Action<BaseEventData> OnBeginDragHandler = null;
    public Action<BaseEventData> OnEndDragHandler = null;
    public void OnPointerClick(PointerEventData eventData)
    {
        OnClickHandler?.Invoke();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        OnPointerDownHandler?.Invoke();
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        OnPointerUpHandler?.Invoke();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        OnEnterHandler?.Invoke();
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        OnExitHandler?.Invoke();
    }


    public void OnPointerMove(PointerEventData eventData)
    {
        OnMoveHandler?.Invoke();
    }
    public void OnDrag(PointerEventData eventData)
    {
        OnDragHandler?.Invoke(eventData);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        OnBeginDragHandler?.Invoke(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        OnEndDragHandler?.Invoke(eventData);
    }
}
