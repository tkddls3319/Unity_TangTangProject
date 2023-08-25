using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Joystick : UI_Base, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler, IDragHandler
{

    enum Images
    {
        BG,
        Handler,
        Icon,
        TuchBg
    }

    Image _background;
    Image _handler;

    float _joustickRadius;
    Vector2 _touchPosition;
    Vector2 _moveDir;


    public override bool Init()
    {
        if(base.Init() == false)
            return false;

        Bind<Image>(typeof(Images));

        _background = GetImage((int)Images.BG);
        _handler = GetImage((int)Images.Handler);
        _joustickRadius = _background.gameObject.GetComponent<RectTransform>().sizeDelta.y / 2;


        return base.Init();
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 touchDir = eventData.position - _touchPosition;

        float moveDist = Mathf.Min(_joustickRadius, touchDir.magnitude);
        _moveDir = touchDir.normalized;

        Vector2 newPosition = _touchPosition + _moveDir * moveDist;
        _handler.transform.position = newPosition;

    }

    public void OnPointerClick(PointerEventData eventData)
    {
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _background.transform.position = eventData.position;
        _handler.transform.position = eventData.position;
        _touchPosition = eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _handler.transform.position = _touchPosition;
        _moveDir = Vector2.zero;


    }
}
