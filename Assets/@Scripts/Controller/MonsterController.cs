using System.Collections;
using System.Collections.Generic;
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
        PlayerController pc = Managers.Object.Player;

        if (pc == null)
            return;

        Vector3 dir = pc.transform.position - transform.position;
        Vector3 nextPos = transform.position + dir.normalized * Time.deltaTime * Data.Speed;

        GetComponent<Rigidbody2D>().MovePosition(nextPos);
        GetComponent<SpriteRenderer>().flipX = dir.x < 0;
    }

    protected override void OnDead()
    {
        base.OnDead();

        ExpController exp = Managers.Object.Spawn<ExpController>(transform.position);
        Managers.Object.Dspawn(this);
    }
}
