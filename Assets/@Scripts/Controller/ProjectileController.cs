using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class ProjectileController : SkillController
{
    CreatureController _master;
    Vector3 _moveDir;

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        return true;
    }
    public void SetInfo(CreatureController master, Vector3 moveDir, SkillData skillData, Transform target = null)
    {
        _master = master;
        Data = skillData;
        _moveDir = moveDir;
        AnimatorController animator = Managers.Resource.Load<AnimatorController>($"{Data.AnimatorName}");
        Animator anim = GetComponent<Animator>();
        anim.runtimeAnimatorController = animator;
        anim.Play(Data.AnimationName);

        StartCoroutine(CoDestroy(Data.LifeTime));
        Init();

    }

    public override void UpdateController()
    {
        Vector3 nextPos = transform.position + _moveDir * Data.Speed * Time.deltaTime;
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

        mc.OnDamaged(_master, Data.Damage * _master.Data.Damage);
        Managers.Object.Dspawn(this);
    }
}
