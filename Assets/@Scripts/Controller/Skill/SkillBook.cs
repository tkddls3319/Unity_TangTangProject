using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SkillBook : MonoBehaviour
{
    public List<SkillBase> SkillList { get; } = new List<SkillBase>();

    public void AddSkill(Define.SkillType type)
    {
        PlayerController player = Managers.Game.Player;
        RepeatSkill skill = gameObject.AddComponent(Type.GetType(type.ToString())) as RepeatSkill;

        skill.Owner = GetComponent<CreatureController>();
        SkillList.Add(skill);


        if (type == Define.SkillType.EnergyBolt)
        {
            skill.Level = 1;
            skill.ActivateSkill();
        }
    }

    public void LevelUpSkill(Define.SkillType type)
    {
        var skill = SkillList.Find(f => f.SkillType == type);

        skill.OnLevelUp();
    }
}
