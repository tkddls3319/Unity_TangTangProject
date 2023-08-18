using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils
{
    public static T FindChild<T>(GameObject go, string name = null, bool recursive = false) where T : Object
    {
        if (go == null)
            return null;

        if (recursive == false)
        {
            Transform transform = go.transform.Find(name);
            if (transform != null)
                return transform.GetComponent<T>();
        }
        else
        {
            foreach (T componenet in go.GetComponentsInChildren<T>())
            {
                if (string.IsNullOrEmpty(name) || componenet.name == name)
                    return componenet;
            }
        }

        return null;
    }


    public static GameObject FindChild(GameObject go, string name = null, bool recursive = false)
    {
        Transform transform = FindChild<Transform>(go, name, recursive);

        if (transform != null)
            return transform.gameObject;

        return null;
    }
}
