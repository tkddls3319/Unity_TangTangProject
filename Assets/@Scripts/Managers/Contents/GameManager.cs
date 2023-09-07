using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
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

    public PlayerController Player { get; set; }
    public GroundController Ground { get; set; }

    public void Init()
    {
        Ground = GameObject.Find("@Ground").GetOrAddComponent<GroundController>();
    }

    public ExpInfo GetGemInfo()
    {

        switch (UnityEngine.Random.Range(0, 3))
        {
            case 0:
                return new ExpInfo(ExpInfo.GemType.Bronze, new Vector3(0.25f, 0.25f, 0.25f));
            case 1:
                return new ExpInfo(ExpInfo.GemType.Silver, new Vector3(0.25f, 0.25f, 0.25f));
            case 2:
                return new ExpInfo(ExpInfo.GemType.Gold, new Vector3(0.35f, 0.35f, 0.35f));
        }
        return null;
    }
}
