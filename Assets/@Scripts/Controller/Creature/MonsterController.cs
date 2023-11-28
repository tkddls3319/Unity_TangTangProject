using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;

public class MonsterController : CreatureController
{
    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        return true;
    }
    private void FixedUpdate()
    {
        PlayerController pc = Managers.Game.Player;

        if (pc == null)
            return;
        ObjectType = Define.ObjectType.Monster;

        if (Status != Define.CreatureState.Hit)
            Status = Define.CreatureState.Moving;

        Vector3 dir = pc.transform.position - transform.position;
        Vector3 nextPos = transform.position + dir.normalized * Time.deltaTime * Speed;

        GetComponent<Rigidbody2D>().MovePosition(nextPos);
        GetComponent<SpriteRenderer>().flipX = dir.x < 0;
    }
    public override void UpdateAnimation()
    {
        switch (Status)
        {
            case Define.CreatureState.Moving:
                _animator.Play("MOVE");
                break;
            case Define.CreatureState.Hit:
                _animator.Play("HIT");
                break;
            case Define.CreatureState.Dead:
                _animator.Play("DEAD");
                break;
        }
    }
    public void SetInfo(CreatureData data)
    {
        CreatureData Data = data.DeepCopy();
        Damage = Data.Damage;
        MaxHp = Data.MaxHp;
        Hp = Data.Hp;
        Speed = Data.Speed;
        Exp = Data.Exp;
        //Sprite spr = Managers.Resource.Load<Sprite>($"{Data.CreatureSprite}");
        //GetComponent<SpriteRenderer>().sprite = spr;
        //AnimatorController animator = Managers.Resource.Load<AnimatorController>($"{Data.CreatureAnimator}");
        //GetComponent<Animator>().runtimeAnimatorController = animator;
        Init();
    }
    public override void OnDead()
    {
        base.OnDead();
        Managers.Game.Player.KillCount++;

        ExpController exp = Managers.Object.Spawn<ExpController>(transform.position);
        exp.SetInfo(Managers.Game.GetGemInfo());



        Managers.Object.Dspawn(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController pc = collision.GetComponent<PlayerController>();
        if (pc == null)
            return;

        pc.OnDamaged(this, Damage);
    }
}
