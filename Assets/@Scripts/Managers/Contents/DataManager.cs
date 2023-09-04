using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class DataManager
{
    public Dictionary<int, SkillData> SkillData { get; private set; } = new Dictionary<int, SkillData>();
    public Dictionary<int, CreatureData> MonsterDatas { get; private set; } = new Dictionary<int, CreatureData>();

    public void Init()
    {
        SkillData sd = new SkillData(1, 10, 1.0f);
        SkillData.Add(1, sd);

        CreatureData jombe = new CreatureData(20, 20, 5.0f, 10, 0);
        MonsterDatas.Add(0, jombe);
    }
}
