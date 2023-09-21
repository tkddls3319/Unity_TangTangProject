using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    public Vector3 CenterPosition
    {
        get
        {
            return _offset.bounds.center;
        }
    }
    private Collider2D _offset;
    public virtual int PrefabId { get; set; }
    public virtual float Damage { get; set; }
    public virtual float MaxHp { get; set; }
    public virtual float Hp { get; set; }
    public virtual float Speed { get; set; }
    public virtual float Exp { get; set; }


    protected Animator _animator;
    public virtual SkillBook Skills { get; set; }
    public override bool Init()
    {
        base.Init();

      Skills = gameObject.GetOrAddComponent<SkillBook>();
        _animator = gameObject.GetComponent<Animator>();
        _offset = GetComponent<Collider2D>();
        return true;
    }

    public virtual void UpdateAnimation() 
    {
    }

    public virtual void OnDamaged(BaseController attacker, float damage)
    {
        Hp -= (int)damage;
        Status = Define.CreatureState.Hit;

        Managers.Object.ShowDamageFont(CenterPosition, damage, 0, transform);
        if (Hp <= 0)
        {
            Hp = 0;
            OnDead();
        }
    }

    public virtual void OnDead()
    {
        Status = Define.CreatureState.Dead;
    }

}
