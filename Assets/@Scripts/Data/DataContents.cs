using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static Define;

public class LevelData
{
    public int Level;
    public float MaxExp;

    public LevelData(int level, float maxExp)
    {
        Level = level;
        MaxExp = maxExp;
    }
}
[Serializable]
public class SkillInfo
{
    public int Level;
    public float Damage;


    public SkillInfo(int level, float damage)
    {
        Level = level;
        Damage = damage;
    }
}
[Serializable]
public class SkillData
{
    public int Id;
    public string Name;
    public int ShotCount;
    public float Speed;
    public float Scala;
    public float ShotTime;
    public float CoolTime;
    public float LifeTime;
    public string AnimationName;
    public string SpriteName;
    public Dictionary<int, SkillInfo> SkillInfos;

    public SkillData()
    {
    }

    public SkillData(int id, string name, int shotCount,  float speed, float scala, float shotTime, float coolTime, float lifeTime, string animationName, string spriteName,Dictionary<int, SkillInfo> skillInfos)
    {
        Id = id;
        Name = name;
        ShotCount = shotCount;
        Speed = speed;
        Scala = scala;
        ShotTime = shotTime;
        CoolTime = coolTime;
        LifeTime = lifeTime;
        AnimationName = animationName;
        SpriteName = spriteName;
        SkillInfos = skillInfos;
    }

    public SkillData DeepCopy()
    {
        SkillData newCopy = new SkillData();
        newCopy.Id = Id;
        newCopy.Name = Name;
        newCopy.ShotCount = ShotCount;
        newCopy.SkillInfos = SkillInfos;
        newCopy.Speed = Speed;
        newCopy.Scala = Scala;
        newCopy.ShotTime = ShotTime;
        newCopy.CoolTime = CoolTime;
        newCopy.LifeTime = LifeTime;
        newCopy.SpriteName = SpriteName;
        newCopy.AnimationName = AnimationName;
        return newCopy;
    }
}

public class CreatureData
{
    public int PrefabId;
    public int Damage;
    public int MaxHp;
    public int Hp;
    public float Speed;
    public float Exp;
    public string Name;
    public string CreatureSprite;
    public string CreatureAnimator;

    public CreatureData()
    {
    }

    public CreatureData(int prefabId, int damage, int maxHp, int hp, float speed, float exp, string name, string creatureSprite, string creatureAnimator)
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