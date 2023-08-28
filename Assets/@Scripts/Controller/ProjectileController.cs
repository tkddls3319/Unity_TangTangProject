using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : SkillController
{
    CreatureController _master;
    Vector3 _moveDir;
    float _speed;
    int _attack;

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        StartDestroy(1);
        return true;
    }

    public void SetInfo(CreatureController master, Vector3 moveDir, float speed, int attack)
    {
        _master = master;
        _moveDir = moveDir;
        _speed = speed;
        _attack = attack;
    }

    public override void UpdateController()
    {
        Vector3 nextPos =  transform.position + _moveDir * _speed * Time.deltaTime;
        GetComponent<Rigidbody2D>().MovePosition(nextPos);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        MonsterController mc = collision.gameObject.GetComponent<MonsterController>();
        if (mc.IsNotNullActive() == false)
            return;

        if (this.IsNotNullActive() == false)
            return;

        mc.OnDamaged(_master, _attack);
        SkillDestory();
        Managers.Object.Dspawn(this);
    }
}
