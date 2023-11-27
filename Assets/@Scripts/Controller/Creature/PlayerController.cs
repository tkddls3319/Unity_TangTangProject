using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : CreatureController
{
   public  Vector2 MoveDir = Vector2.zero;

    public Transform Indicator { get; set; }
    public Transform FireSocket { get; set; }

    public event Action OnPlayerDataUpdated;
    public event Action OnPlayerLevelUp;

    public Vector3 PlayerCenterPos { get { return Indicator.transform.position; } }
    public Vector3 PlayerDirection { get { return (FireSocket.transform.position - PlayerCenterPos).normalized; } }

    public float _ItemCollecRange { get; } = 1.0f;

    public float CoolTime { get; set; } = 0.5f;


    public override int PrefabId
    {
        get { return Managers.Game.ContinueInfo.PlayerDataId; }
        set { Managers.Game.ContinueInfo.PlayerDataId = value; }
    }
    public override float Damage
    {
        get { return Managers.Game.ContinueInfo.Atk; }
        set { Managers.Game.ContinueInfo.Atk = value; }
    }
    public override float MaxHp
    {
        get { return Managers.Game.ContinueInfo.MaxHp; }
        set { Managers.Game.ContinueInfo.MaxHp = value; }
    }
    public override float Hp
    {
        get { return Managers.Game.ContinueInfo.Hp; }
        set { Managers.Game.ContinueInfo.Hp = value; }
    }
    public override float Speed
    {
        get { return Managers.Game.ContinueInfo.MoveSpeed; }
        set { Managers.Game.ContinueInfo.MoveSpeed = value; }
    }
    public int Level
    {
        get { return Managers.Game.ContinueInfo.Level; }
        set { Managers.Game.ContinueInfo.Level = value; }
    }
    public override float Exp
    {
        get { return Managers.Game.ContinueInfo.Exp; }
        set
        {
            Managers.Game.ContinueInfo.Exp = value;
            if (TotalExp <= Managers.Game.ContinueInfo.Exp)
            {
                LevelUp();
            }

            OnPlayerDataUpdated?.Invoke();
        }
    }
    public float TotalExp
    {
        get
        {
            Managers.Game.ContinueInfo.TotalExp = Managers.Data.LevelDatas[Level].MaxExp;
            return Managers.Game.ContinueInfo.TotalExp;
        }
    }

    public int KillCount
    {
        get { return Managers.Game.ContinueInfo.KillCount; }
        set
        {
            Managers.Game.ContinueInfo.KillCount = value;
            OnPlayerDataUpdated?.Invoke();
        }
    }
    public void ContinueInfoSettion(CreatureData data)
    {
        CreatureData Data = data.DeepCopy();
        Damage = Data.Damage;
        MaxHp = Data.MaxHp;
        Hp = Data.Hp;
        Speed = Data.Speed;
        Exp = Data.Exp;
    }
    public void LevelUp()
    {
        OnPlayerLevelUp?.Invoke();

        Level += 1;
        Managers.Game.ContinueInfo.Exp = 0;
    }

    private void OnDestroy()
    {
        if (Managers.Game != null)
            Managers.Game.OnMoveDir -= HandleOnMoveChange;
    }
    private void Start()
    {
        #region Skill µî·Ï
       //Skills.AddSkill(Define.SkillType.EnergyBolt);
        foreach (Define.SkillType enumItem in Enum.GetValues(typeof(Define.SkillType)))
            Skills.AddSkill(enumItem);
        #endregion
    }
    public override bool Init()
    {
        base.Init();

        Managers.Game.OnMoveDir += HandleOnMoveChange;

        ObjectType = Define.ObjectType.Player;

        Indicator = Utils.FindChild<Transform>(gameObject, "Indicator");
        FireSocket = Utils.FindChild<Transform>(Indicator.gameObject, "FireSocket");
      
        //StartProjectTile();
        return true;
    }

    public void Healing()
    {
        int randHp = UnityEngine.Random.Range(60, 150);
        Hp += randHp;
        Managers.Object.ShowDamageFont(PlayerCenterPos, 0, randHp, transform);
    }
    public override void UpdateAnimation()
    {
        switch (Status)
        {
            case Define.CreatureState.Idle:
                _animator.Play("IDLE");
                break;
            case Define.CreatureState.Moving:
                _animator.Play("MOVE");
                break;
            case Define.CreatureState.Skill:
                break;
            case Define.CreatureState.Hit:
                _animator.Play("HIT");
                break;
            case Define.CreatureState.Dead:
                _animator.Play("DEAD");
                break;
        }
    }
    public override void UpdateController()
    {
        MovePlayer();
        CollectionItem();
    }

    void CollectionItem()
    {
        var items = Managers.Game.Ground.GetObjectList(transform.position, _ItemCollecRange);

        foreach (DropItemController item in items)
        {
            Vector3 dir = item.transform.position - transform.position;

            switch (item.ItemType)
            {
                case Define.ObjectType.Bomb:
                    if (dir.sqrMagnitude <= item.CollectDist * item.CollectDist)
                    {
                        item.GetItem();
                    }
                    break;
                default:
                    float cd = item.CollectDist * 1;
                    if (dir.sqrMagnitude <= cd * cd)
                    {
                        item.GetItem();
                    }
                    break;
            }
        }
    }

    private void HandleOnMoveChange(Vector2 dir)
    {
        MoveDir = dir;
        if (Status != Define.CreatureState.Hit)
            Status = Define.CreatureState.Moving;
    }

    void MovePlayer()
    {
        Vector3 dir = MoveDir * Speed * Time.deltaTime;
        transform.position += dir;

        if (MoveDir != Vector2.zero)
        {
            Indicator.eulerAngles = new Vector3(0, 0, MathF.Atan2(-dir.x, dir.y) * 180 / MathF.PI);
        }
        else
        {
            if (Status != Define.CreatureState.Idle)
                Status = Define.CreatureState.Idle;
        }

        GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        GetComponent<SpriteRenderer>().flipX = dir.x > 0;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {

    }

    public override void OnDead()
    {
        base.OnDead();
        Managers.Game.OnPlayerDead();
    }

    #region Projeectile

    //Coroutine _coFireProjectTile;
    //void StartProjectTile()
    //{
    //    if (_coFireProjectTile != null)
    //    {
    //        StopCoroutine(_coFireProjectTile);
    //        _coFireProjectTile = null;
    //    }

    //    _coFireProjectTile = StartCoroutine(CoStartProjecTile());
    //}
    //IEnumerator CoStartProjecTile()
    //{
    //    WaitForSeconds wait = new WaitForSeconds(CoolTime);

    //    while (true)
    //    {
    //        int id = UnityEngine.Random.Range(1, 11);
    //        SkillData data = null;
    //        if (Managers.Data.SkillDatas.TryGetValue(id, out data) != false)
    //        {
    //            ProjectileController pc = Managers.Object.Spawn<ProjectileController>(_fireSocket.position, /*(int)SkillID*/id);
    //            pc.SetInfo(this, (_fireSocket.position - _indicator.position).normalized, data);
    //        }

    //        yield return wait;
    //    }
    //}
    #endregion
}
