using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class SkillBook : MonoBehaviour
{

    public List<SkillBase> SkillList { get; } = new List<SkillBase>();


    public void AddSkill(Define.SkillType type)
    {
        PlayerController player = Managers.Game.Player;
        RepeatSkill skill = gameObject.AddComponent(Type.GetType(type.ToString())) as RepeatSkill;

        skill.ActivateSkill((int)type);
        skill.Owner = GetComponent<CreatureController>();
        SkillList.Add(skill);
    }
}
