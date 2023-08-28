using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureController : BaseController
{
    protected float _speed = 5.0f;
    public int HP { get; set; }


    public virtual void OnDamaged(BaseController attacker, int damage)
    {
        HP -= damage;

        if(HP<=0)
        {
            HP = 0;
            OnDead();
        }
    }

    protected virtual void OnDead()
    {
        //TODO : Á×¾úÀ»¶§.
    }

}
