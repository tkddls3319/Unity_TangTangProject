using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public class CreatureController : BaseController
{
    Define.CreatureState _status = Define.CreatureState.Moving;

    public Define.CreatureState Status
    {
        get { return _status; }
        set
        {
            _status = value;
            UpdateAnimation();
        }
    }
    public CreatureData Data { get; set; }

    protected Animator _animator;

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        _animator = gameObject.GetComponent<Animator>();

        return true;
    }

    public virtual void UpdateAnimation() 
    {
    }

    public virtual void OnDamaged(BaseController attacker, int damage)
    {
        Data.Hp -= damage;
        Status = Define.CreatureState.Hit;

        //Debug.Log($"{gameObject.name} : {Data.Hp}");
        if (Data.Hp <= 0)
        {
            Data.Hp = 0;
            OnDead();
        }
    }

    protected virtual void OnDead()
    {
        Status = Define.CreatureState.Dead;
    }

}
