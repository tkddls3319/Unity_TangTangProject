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
    public int Damage;
    public float LifeTime;

    public SkillData(int id, int damage, float lifeTime)
    {
        Id = id;
        Damage = damage;
        LifeTime = lifeTime;
    }
}

public class CreatureData
{
    public int Id;
    public int Damage;
    public int MaxHp;
    public int Hp;
    public float Speed;
    public int Exp;
    public string PrefabString;

    public CreatureData()
    {
    }
    public CreatureData(int id, int damage, int maxHp, int hp, float speed, int exp, string prefabString)
    {
        Id = id;
        Damage = damage;
        MaxHp = maxHp;
        Hp = hp;
        Speed = speed;
        Exp = exp;
        PrefabString = prefabString;
    }

    public CreatureData DeepCopy()
    {
        CreatureData newCopy = new CreatureData();
        newCopy.Damage = Damage;
        newCopy.MaxHp = MaxHp;
        newCopy.Hp = Hp;
        newCopy.Speed = Speed;
        newCopy.Exp = Exp;
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