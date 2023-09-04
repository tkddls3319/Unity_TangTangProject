using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureController : BaseController
{

    public CreatureData Data { get; set; }

    public virtual void OnDamaged(BaseController attacker, int damage)
    {
        Data.Hp -= damage;

        if(Data.Hp <= 0)
        {
            Data.Hp = 0;
            OnDead();
        }
    }

    protected virtual void OnDead()
    {
        //TODO : Á×¾úÀ»¶§.
    }

}
