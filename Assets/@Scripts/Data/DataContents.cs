using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Define;


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
    public int Damage;
    public int MaxHp;
    public int Hp;
    public float Speed;
    public int MaxExp;
    public int Exp;

    public CreatureData()
    {
    }
    public CreatureData(int damage, int maxHp, int hp, float speed, int maxExp, int exp)
    {
        Damage = damage;
        MaxHp = maxHp;
        Hp = hp;
        Speed = speed;
        MaxExp = maxExp;
        Exp = exp;
    }

    public CreatureData DeepCopy()
    {
        CreatureData newCopy = new CreatureData();
        newCopy.Damage = Damage;
        newCopy.MaxHp = MaxHp;
        newCopy.Hp = Hp;
        newCopy.Speed = Speed;
        newCopy.MaxExp = MaxExp;
        newCopy.Exp = Exp;
        return newCopy;
    }
}