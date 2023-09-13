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
    public static void DestroyChilds(this GameObject go)
    {
        Transform[] children = new Transform[go.transform.childCount];

        for (int i = 0; i < go.transform.childCount; i++)
        {
            children[i] = go.transform.GetChild(i);
        }

        foreach (var item in children)
        {
            Managers.Resource.Destroy(item.gameObject);
        }
    }
}
