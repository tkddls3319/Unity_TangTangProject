using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class Extension
{
    public static void BindEvent(this GameObject go, Action action, Define.UIEvent type = Define.UIEvent.Click)
    {
        UI_Base.BindEvent(go, action, type);  
    }

    public static bool IsNotNullActive(this GameObject go)
    {
        return go != null && go.activeSelf;
    }

    public static bool IsNotNullActive(this BaseController bc)
    {
        return bc != null && bc.isActiveAndEnabled;
    }
}
