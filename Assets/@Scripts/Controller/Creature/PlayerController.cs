using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : CreatureController
{
    Vector2 _moveDir = Vector2.zero;

    Transform _indicator;
    Transform _fireSocket;

    public event Action OnPlayerDataUpdated;

    public Vector3 PlayerCenterPos { get { return _indicator.transform.position; } }

    public Define.SkillType SkillID { get; set; } = Define.SkillType.Hits1;

    public float _ItemCollecRange { get; } = 1.0f;


    //TODO : �׽�Ʈ
    public float CoolTime { get; set; } = 0.5f;

    float _exp;
    public float Exp
    {
        get { return _exp; }
        set
        {
            _exp = value;
            OnPlayerDataUpdated?.Invoke();
        }
    }
    int _killCount;
    public int KillCount
    {
        get { return _killCount; }
        set
        {
            _killCount = value;
            OnPlayerDataUpdated?.Invoke();
        }
    }

    private void OnDestroy()
    {
        if (Managers.Game != null)
            Managers.Game.OnMoveDir -= HandleOnMoveChange;
    }

    public override bool Init()
    {
        base.Init();

        Managers.Game.OnMoveDir += HandleOnMoveChange;

        ObjectType = Define.ObjectType.Player;

        _indicator = Utils.FindChild<Transform>(gameObject, "Indicator");
        _fireSocket = Utils.FindChild<Transform>(_indicator.gameObject, "FireSocket");

        StartProjectTile();

        return true;
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

            if (item.ItemType == Define.ObjectType.Exp)
            {
                float cd = item.CollectDist * 1;
                if (dir.sqrMagnitude <= cd * cd)
                {
                    item.GetItem();
                }
                break;
            }
            else if (item.ItemType != Define.ObjectType.Bomb)
            {
                if (dir.sqrMagnitude <= item.CollectDist * item.CollectDist)
                {
                    item.GetItem();
                }
                break;
            }
        }
    }

    private void HandleOnMoveChange(Vector2 dir)
    {
        _moveDir = dir;
        if (Status != Define.CreatureState.Hit)
            Status = Define.CreatureState.Moving;
    }

    void MovePlayer()
    {
        Vector3 dir = _moveDir * Data.Speed * Time.deltaTime;
        transform.position += dir;

        if (_moveDir != Vector2.zero)
        {
            _indicator.eulerAngles = new Vector3(0, 0, MathF.Atan2(-dir.x, dir.y) * 180 / MathF.PI);
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

    Coroutine _coFireProjectTile;
    void StartProjectTile()
    {
        if (_coFireProjectTile != null)
        {
            StopCoroutine(_coFireProjectTile);
            _coFireProjectTile = null;
        }

        _coFireProjectTile = StartCoroutine(CoStartProjecTile());
    }
    IEnumerator CoStartProjecTile()
    {
        WaitForSeconds wait = new WaitForSeconds(CoolTime);

        while (true)
        {
            int id = UnityEngine.Random.Range(1, 11);
            SkillData data = null;
            if (Managers.Data.SkillDatas.TryGetValue(id, out data) != false)
            {
                ProjectileController pc = Managers.Object.Spawn<ProjectileController>(_fireSocket.position, /*(int)SkillID*/id);
                pc.SetInfo(this, (_fireSocket.position - _indicator.position).normalized, data);
            }

            yield return wait;
        }
    }

    #endregion
}
