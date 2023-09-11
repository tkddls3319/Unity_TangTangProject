using System.Collections;
using System.Collections.Generic;
using System.Xml.XPath;
using UnityEngine;
using UnityEngine.Animations;

public class DataManager
{
    public Dictionary<int, PlayerData> PlayerDatas { get; private set; } = new Dictionary<int, PlayerData>();
    public Dictionary<int, SkillData> SkillDatas { get; private set; } = new Dictionary<int, SkillData>();
    public Dictionary<int, CreatureData> MonsterDatas { get; private set; } = new Dictionary<int, CreatureData>();

    public void Init()
    {
        #region Player
        PlayerDatas.Add(1, new PlayerData(level : 1, maxExp : 50));
        PlayerDatas.Add(2, new PlayerData(level : 2, maxExp : 70));
        PlayerDatas.Add(3, new PlayerData(level : 3, maxExp : 110));
        PlayerDatas.Add(4, new PlayerData(level : 4, maxExp : 150));
        PlayerDatas.Add(5, new PlayerData(level : 5, maxExp : 200));
        PlayerDatas.Add(6, new PlayerData(level : 6, maxExp : 250));
        PlayerDatas.Add(7, new PlayerData(level : 7, maxExp : 350));
        PlayerDatas.Add(8, new PlayerData(level : 8, maxExp : 450));
        PlayerDatas.Add(9, new PlayerData(level : 9, maxExp : 550));
        #endregion

        #region Skill
        SkillDatas.Add(1, new SkillData(id: 1, damage: 10, lifeTime: 1.0f));
        #endregion

        #region Monster
        MonsterDatas.Add(0, new CreatureData(id: 0, damage: 10, maxHp: 100, hp: 100, speed: 3.0f, exp: 9999, prefabString: "Player.prefab")); //Player
        MonsterDatas.Add(1, new CreatureData(id: 1, damage: 10, maxHp: 20, hp: 20, speed: 1.0f, exp: 1, prefabString: "Zombe.prefab"));
        MonsterDatas.Add(2, new CreatureData(id: 2, damage: 20, maxHp: 30, hp: 30, speed: 1.5f, exp: 2, prefabString: "Skull.prefab"));
        #endregion
    }
}
