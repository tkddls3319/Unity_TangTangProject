using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AdaptivePerformance.Provider;
using UnityEngine.UIElements;

public class ProjectileController : SkillBase
{
    public SkillBase Skill;
    Vector2 _spawnPos;
    Vector3 _moveDir = Vector3.zero;
    Vector3 _target = Vector3.zero;

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        return true;
    }
    public void SetInfo(CreatureController owner, Vector3 startPos, Vector3 moveDir, Vector3 targetPos, SkillBase skill)
    {
        Owner = owner;
        Skill = skill;
        Level = skill.Level;
        SkillData = skill.SkillData;
        _moveDir = moveDir;
        _spawnPos = startPos;
        _target = targetPos;
        gameObject.transform.localScale = Vector3.one * Skill.SkillData.Scala;

        AnimatorController animator = Managers.Resource.Load<AnimatorController>("SkillAnimator.controller");
        Animator anim = GetComponent<Animator>();

        switch (skill.SkillType)
        {
            case Define.SkillType.EnergyBolt:
                StartCoroutine(CoEnergyBolt());
                GetComponent<SpriteRenderer>().color = new Color(0 / 255f, 0 / 255f, 0 / 255f, 255 / 255f);
                break;
            case Define.SkillType.EnergyBolt2:
                GetComponent<SpriteRenderer>().color = new Color(229 / 255f, 79 / 255f, 49 / 255f, 255 / 255f);
                StartCoroutine(CoEnergyBolt2());
                break;
            case Define.SkillType.ElectricBolt:
                GetComponent<SpriteRenderer>().color = new Color(208 / 255f, 255 / 255f, 0 / 255f, 255 / 255f);

                StartCoroutine(CoElectricBolt());
                break;
            case Define.SkillType.EnergyWave:
                GetComponent<SpriteRenderer>().color = new Color(255 / 255f, 0 / 255f, 151 / 255f, 255 / 255f);
                StartCoroutine(CoEnergyWave());
                break;
            case Define.SkillType.TowEnergyShot:
                StartCoroutine(CoTowEnergyShot());
                break;
        }

        anim.runtimeAnimatorController = animator;
        anim.Play(SkillData.AnimationName);

        StartCoroutine(CoDestroy(Skill.SkillData.LifeTime));
    }

    public override void UpdateController()
    {
    }
    #region 스킬 코루틴
    IEnumerator CoEnergyBolt()
    {
        while (true)
        {
            Vector3 nextPos = transform.position + _moveDir * Skill.SkillData.Speed * Time.deltaTime;
            GetComponent<Rigidbody2D>().MovePosition(nextPos);
            yield return new WaitForFixedUpdate();
        }
    }
    IEnumerator CoEnergyBolt2()
    {
        while (true)
        {
            Vector3 nextPos = Vector3.Slerp(transform.position, _target, Skill.SkillData.Speed * Time.deltaTime);
            GetComponent<Rigidbody2D>().MovePosition(nextPos);
            yield return new WaitForFixedUpdate();
        }
    }
    IEnumerator CoElectricBolt()
    {
        while (true)
        {
            Vector3 nextPos = transform.position + _moveDir * Skill.SkillData.Speed * Time.deltaTime;
            GetComponent<Rigidbody2D>().MovePosition(nextPos);
            yield return new WaitForFixedUpdate();
        }
    }
    IEnumerator CoEnergyWave()
    {
        while (true)
        {
            Vector3 nextPos = transform.position + _moveDir * Skill.SkillData.Speed * Time.deltaTime;
            GetComponent<Rigidbody2D>().MovePosition(nextPos);

            float angle = Mathf.Atan2(_moveDir.y, _moveDir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);

            yield return new WaitForFixedUpdate();
        }
    }
    IEnumerator CoTowEnergyShot()
    {
        while (true)
        {
            GetComponent<Rigidbody2D>().MovePosition(Owner.transform.position + (_moveDir * 0.2f));
            float angle = Mathf.Atan2(_moveDir.y, _moveDir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
            yield return new WaitForFixedUpdate();
        }
    }
    #endregion
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

        switch (Skill.SkillType)
        {
            case Define.SkillType.EnergyBolt:
                Managers.Object.Dspawn(this);
                break;
            case Define.SkillType.EnergyBolt2:
                Managers.Object.Dspawn(this);
                break;
            case Define.SkillType.ElectricBolt:
                break;
            case Define.SkillType.EnergyWave:
                break;
            case Define.SkillType.TowEnergyShot:
                break;
        }

        mc.OnDamaged(Owner, Skill.SkillData.SkillInfos[Level].Damage * Owner.Damage);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        MonsterController mc = collision.gameObject.GetComponent<MonsterController>();
        if (mc.IsMyNotNullActive() == false)
            return;

        if (this.IsMyNotNullActive() == false)
            return;
    }
}
