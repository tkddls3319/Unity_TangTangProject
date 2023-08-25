using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    public Define.ObjectType ObjectType { get; protected set; }
    bool _init = false;
    private void Awake()
    {
        Init();
    }

    public virtual bool Init()
    {
        if (_init)
            return false;

        _init = true;
        return true;
    }

    private void Update()
    {
        UpdateController();
    }

    public virtual void UpdateController()
    {
    }
}
