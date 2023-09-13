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

    public int Stamina = 1;//Define.MAX_STAMINA;
    public int Gold = 0;
    public int Dia = 300;

    public int TotalMonsterKillCount = 0;
    public int TotalBossKillCount = 0;

    //public ContinueData ContinueInfo = new ContinueData();
}

public class ContinueData
{
    public bool isContinue { get { return SavedBattleSkill.Count > 0; } }
    public int PlayerDataId;
    public float Hp;
    public float MaxHp;
    public float MaxHpBonusRate = 1;
    public float HealBonusRate = 1;
    public float HpRegen;
    public float Atk;
    public float AttackRate = 1;
    public float Def;
    public float DefRate;
    public float MoveSpeed;
    public float MoveSpeedRate = 1;
    public float TotalExp;
    public int Level = 1;
    public float Exp;
    public float CriRate;
    public float CriDamage = 1.5f;
    public float DamageReduction;
    public float ExpBonusRate = 1;
    public float SoulBonusRate = 1;
    public float CollectDistBonus = 1;
    public int KillCount;
    public int SkillRefreshCount = 3;
    public float SoulCount;

    //public List<SupportSkillData> SoulShopList = new List<SupportSkillData>();
    //public List<SupportSkillData> SavedSupportSkill = new List<SupportSkillData>();
    public Dictionary<Define.SkillType, int> SavedBattleSkill = new Dictionary<Define.SkillType, int>();

    public int WaveIndex;
    public void Clear()
    {
        // 각 변수의 초기값 설정
        PlayerDataId = 0;
        Hp = 0f;
        MaxHp = 0f;
        MaxHpBonusRate = 1f;
        HealBonusRate = 1f;
        HpRegen = 0f;
        Atk = 0f;
        AttackRate = 1f;
        Def = 0f;
        DefRate = 0f;
        MoveSpeed = 0f;
        MoveSpeedRate = 1f;
        TotalExp = 0f;
        Level = 1;
        Exp = 0f;
        CriRate = 0f;
        CriDamage = 1.5f;
        DamageReduction = 0f;
        ExpBonusRate = 1f;
        SoulBonusRate = 1f;
        CollectDistBonus = 1f;

        KillCount = 0;
        SoulCount = 0f;
        SkillRefreshCount = 3;

        //SoulShopList.Clear();
        //SavedSupportSkill.Clear();
        SavedBattleSkill.Clear();

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
                return new ExpInfo(ExpInfo.GemType.Bronze, new Vector3(0.25f, 0.25f, 0.25f));
            case 1:
                return new ExpInfo(ExpInfo.GemType.Silver, new Vector3(0.25f, 0.25f, 0.25f));
            case 2:
                return new ExpInfo(ExpInfo.GemType.Gold, new Vector3(0.35f, 0.35f, 0.35f));
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
