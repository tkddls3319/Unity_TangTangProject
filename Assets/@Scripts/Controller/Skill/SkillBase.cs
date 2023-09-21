using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class SkillBase : BaseController
{
    public CreatureController Owner { get; set; }
    public Define.SkillType SkillType { get; set; }

    int level = 1;
    public int Level
    {
        get { return level; }
        set { level = value; }
    }

    public SkillData _skillData;
    public SkillData SkillData
    {
        get
        {
            return _skillData;
        }
        set
        {
            _skillData = value;
        }
    }
    public virtual void ActivateSkill(int ID)
    {
        UpdateSkillData(ID);
    }

    public SkillData UpdateSkillData(int dataId = 0)
    {
        SkillData skillData = new SkillData();

        if(Managers.Data.SkillDatas.TryGetValue(dataId, out skillData) == false)
            return SkillData;


        SkillData = skillData.DeepCopy();

        return SkillData;
    }

    protected virtual void GenerateProjectile(CreatureController owner, Vector3 startPos, Vector3 dir, Vector3 targetPos, SkillBase skill)
    {
        ProjectileController pc = Managers.Object.Spawn<ProjectileController>(startPos, 1);
        pc.SetInfo(owner, startPos, dir, targetPos, skill);
    }
}
