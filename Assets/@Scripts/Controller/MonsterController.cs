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

        _speed = 3.0f;

        return true;
    }
    private void FixedUpdate()
    {
        PlayerController pc = Managers.Object.Player;

        if (pc == null)
            return;

        Vector3 dir = pc.transform.position - transform.position;
        Vector3 nextPos = transform.position  + dir.normalized * Time.deltaTime * _speed;

        GetComponent<Rigidbody2D>().MovePosition(nextPos);
        GetComponent<SpriteRenderer>().flipX = dir.x > 0;
    }

    protected override void OnDead()
    {
        base.OnDead();

        Managers.Object.Dspawn(this);
    }
}
