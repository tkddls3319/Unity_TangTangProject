using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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