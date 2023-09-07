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

        return true;
    }

    public void SetInfo(CreatureController master, Vector3 moveDir, float speed, int attack)
    {
        _master = master;
        _moveDir = moveDir;
        _speed = speed;
        _attack = attack;

        StartCoroutine(CoDestroy(5f));
    }

    public override void UpdateController()
    {
        Vector3 nextPos = transform.position + _moveDir * _speed * Time.deltaTime;
        GetComponent<Rigidbody2D>().MovePosition(nextPos);
    }

    IEnumerator CoDestroy(float lifeTime)
    {
        yield return new WaitForSeconds(lifeTime);
        Managers.Object.Dspawn(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        MonsterController mc = collision.gameObject.GetComponent<MonsterController>();
        if (mc.IsMyNotNullActive() == false)
            return;

        if (this.IsMyNotNullActive() == false)
            return;

        mc.OnDamaged(_master, _attack + _master.Data.Damage);
        Managers.Object.Dspawn(this);
    }
}
