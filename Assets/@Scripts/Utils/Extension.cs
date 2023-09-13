using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public static class Extension
{
    public static void BindEvent(this GameObject go, Action action = null, Action<BaseEventData> dragAction = null, Define.UIEvent type = Define.UIEvent.Click)
    {
        UI_Base.BindEvent(go, action, dragAction, type);
    }

    public static bool IsMyNotNullActive(this GameObject go)
    {
        return go != null && go.activeSelf;
    }

    public static bool IsMyNotNullActive(this BaseController bc)
    {
        return bc != null && bc.isActiveAndEnabled;
    }
}
