using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Define;

public class PlayerData
{
    public int Level;
    public float MaxExp;

    public PlayerData(int level, float maxExp)
    {
        Level = level;
        MaxExp = maxExp;
    }
}


public class SkillData
{
    public int Id;
    public float Damage;
    public float Speed;
    public float Scala;
    public float CoolTime;
    public float LifeTime;
    public string AnimatorName;
    public string AnimationName;

    public SkillData(int id, float damage, float speed, float scala, float coolTime, float lifeTime, string animatorName, string animationName)
    {
        Id = id;
        Damage = damage;
        Speed = speed;
        Scala = scala;
        CoolTime = coolTime;
        LifeTime = lifeTime;
        AnimatorName = animatorName;
        AnimationName = animationName;
    }
}

public class CreatureData
{
    public int PrefabId;
    public int Damage;
    public int MaxHp;
    public int Hp;
    public float Speed;
    public int Exp;
    public string Name;
    public string CreatureSprite;
    public string CreatureAnimator;

    public CreatureData()
    {
    }

    public CreatureData(int prefabId, int damage, int maxHp, int hp, float speed, int exp, string name, string creatureSprite, string creatureAnimator)
    {
        PrefabId = prefabId;
        Damage = damage;
        MaxHp = maxHp;
        Hp = hp;
        Speed = speed;
        Exp = exp;
        Name = name;
        CreatureSprite = creatureSprite;
        CreatureAnimator = creatureAnimator;
    }

    public CreatureData DeepCopy()
    {
        CreatureData newCopy = new CreatureData();
        newCopy.PrefabId = PrefabId;
        newCopy.Damage = Damage;
        newCopy.MaxHp = MaxHp;
        newCopy.Hp = Hp;
        newCopy.Speed = Speed;
        newCopy.Exp = Exp;
        newCopy.Name = Name;
        newCopy.CreatureSprite = CreatureSprite;
        newCopy.CreatureAnimator = CreatureAnimator;
        return newCopy;
    }
}

public class SprietData
{
    public int Id;
    public string PrefabString;

    public SprietData()
    {
    }
    public SprietData(int id, string prefabString)
    {
        Id = id;
        PrefabString = prefabString;
    }
}