using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CreatureController
{
    enum Status
    {
        Idle,
        Move,
        Attack,
        Skill,
    }

    Vector2 _moveDir = Vector2.zero;

    Transform _indicator;
    Transform _fireSocket;

    public Define.Projectile SkillID { get; set; } = Define.Projectile.Hits1; 
    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        Data = new CreatureData(1000, 1000, 5.0f, 0, 9999);

        Managers.Game.OnMoveDir -= HandleOnMoveChange;
        Managers.Game.OnMoveDir += HandleOnMoveChange;

        ObjectType = Define.ObjectType.Player;

        _indicator = Utils.FindChild<Transform>(gameObject, "Indicator");
        _fireSocket = Utils.FindChild<Transform>(_indicator.gameObject, "FireSocket");

        StartProjectTile();

        return true;
    }
    public override void UpdateController()
    {
        MovePlayer();
    }

    private void HandleOnMoveChange(Vector2 dir)
    {
        _moveDir = dir;
    }

    void MovePlayer()
    {
        Vector3 dir = _moveDir * Data.Speed * Time.deltaTime;
        transform.position += dir;

        if (_moveDir != Vector2.zero)
        {
            _indicator.eulerAngles = new Vector3(0, 0, MathF.Atan2(-dir.x, dir.y) * 180 / MathF.PI);
        }

        GetComponent<Rigidbody2D>().velocity = Vector3.zero;
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
        WaitForSeconds wait = new WaitForSeconds(0.5f);
       
        while (true)
        {
            ProjectileController pc = Managers.Object.Spawn<ProjectileController>(_fireSocket.position, (int)SkillID);
            pc.SetInfo(this, (_fireSocket.position - _indicator.position).normalized, 50.0f, 1);

            yield return wait;
        }
    }

    private void OnDestroy()
    {
        if (Managers.Game != null)
            Managers.Game.OnMoveDir -= HandleOnMoveChange;
    }
    #endregion
}
