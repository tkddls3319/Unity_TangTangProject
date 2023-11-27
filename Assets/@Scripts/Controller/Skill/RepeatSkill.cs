using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RepeatSkill : SkillBase
{
    public override bool Init()
    {
        base.Init();
        return true;
    }


    #region Skill

    Coroutine _coStartSkill;

    public override void ActivateSkill()
    {
        base.ActivateSkill();

        if (_coStartSkill != null)
            StopCoroutine(_coStartSkill);

        gameObject.SetActive(true);
        _coStartSkill = StartCoroutine(CoStartSkill());
    }
    protected abstract void DoSkillJob();
    IEnumerator CoStartSkill()
    {
        WaitForSeconds wait = new WaitForSeconds(SkillData.CoolTime);

        yield return wait;
        while (true)
        {
            DoSkillJob();
            yield return wait;
        }
    }
    #endregion
}
