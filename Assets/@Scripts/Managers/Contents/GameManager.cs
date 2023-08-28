using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public event Action<Vector2> OnMoveDir;

    Vector2 _moveDir;
    public Vector2 MoveDir
    {
        get
        {
            return _moveDir;
        }
        set
        {
            _moveDir = value;
            OnMoveDir?.Invoke(value);
        }
    }
}
