using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;


public class GameData
{
    public int UserLevel = 1;
    public string UserName = "Player";

    public int Stamina = 15;//Define.MAX_STAMINA;
    public int Gold = 0;
    public int Dia = 300;

    public int TotalMonsterKillCount = 0;
    public int TotalBossKillCount = 0;

    public ContinueData ContinueInfo = new ContinueData();
}

public class ContinueData
{
    public int PlayerDataId;
    public float Hp;
    public float MaxHp;
    public float HpRegen;
    public float Atk;
    public float Def;
    public float MoveSpeed;
    public float TotalExp;
    public int Level = 1;
    public float Exp;
    public float CriDamage = 1.5f;
    public float DamageReduction;
    public int KillCount;
    public int WaveIndex;

    public void Clear()
    {
        PlayerDataId = 0;
        Hp = 0f;
        MaxHp = 0f;
        HpRegen = 0f;
        Atk = 0f;
        Def = 0f;
        MoveSpeed = 0f;
        TotalExp = 0f;
        Level = 1;
        Exp = 0f;
        CriDamage = 1.5f;
        DamageReduction = 0f;
        KillCount = 0;
    }
}
public class GameManager
{
    #region GameData
    public GameData _gameData = new GameData();

    public int UserLevel
    {
        get { return _gameData.UserLevel; }
        set { _gameData.UserLevel = value; }
    }
    public int Stamina
    {
        get { return _gameData.Stamina; }
        set
        {
            _gameData.Stamina = value;
            //SaveGame();
            OnResourcesChagned?.Invoke();
        }
    }
    public int Gold
    {
        get { return _gameData.Gold; }
        set
        {
            _gameData.Gold = value;
            //SaveGame();
            OnResourcesChagned?.Invoke();
        }
    }
    public int Dia
    {
        get { return _gameData.Dia; }
        set
        {
            _gameData.Dia = value;
            //SaveGame();
            OnResourcesChagned?.Invoke();
        }
    }
    #endregion
    public ContinueData ContinueInfo
    {
        get { return _gameData.ContinueInfo; }
        set
        {
            _gameData.ContinueInfo = value;
        }
    }

    #region Action
    public event Action<Vector2> OnMoveDir;
    public event Action OnResourcesChagned;
    #endregion

    #region Player
    public PlayerController Player { get; set; }
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
    #endregion

    public GroundController Ground { get; set; }

    public float TimeRemaining = 60;
    public void Init()
    {
    }

    public ExpInfo GetGemInfo()
    {

        switch (UnityEngine.Random.Range(0, 3))
        {
            case 0:
                return new ExpInfo(ExpInfo.GemType.Bronze, new Vector3(0.15f, 0.15f, 0.15f));
            case 1:
                return new ExpInfo(ExpInfo.GemType.Silver, new Vector3(0.15f, 0.15f, 0.15f));
            case 2:
                return new ExpInfo(ExpInfo.GemType.Gold, new Vector3(0.20f, 0.20f, 0.20f));
        }
        return null;
    }

    public void OnPlayerDead()
    {
        GameOver();
    }
    public void GameOver()
    {
        Player.StopAllCoroutines();
        Managers.Scene.LoadScene(Define.Scene.LobbyScene);
    }
}
