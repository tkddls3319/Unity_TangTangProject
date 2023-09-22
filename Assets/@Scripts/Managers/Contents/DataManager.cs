using System.Collections;
using System.Collections.Generic;
using System.Xml.XPath;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UIElements;

public class DataManager
{
    public Dictionary<int, LevelData> LevelDatas { get; private set; } = new Dictionary<int, LevelData>();
    public Dictionary<int, SkillData> SkillDatas { get; private set; } = new Dictionary<int, SkillData>();
    public Dictionary<int, CreatureData> MonsterDatas { get; private set; } = new Dictionary<int, CreatureData>();
    public Dictionary<int, SprietData> SpriteDatas { get; private set; } = new Dictionary<int, SprietData>();

    public void Init()
    {
        #region Player
        for (int i = 1; i < 100; i++)
            LevelDatas.Add(i, new LevelData(level: i, maxExp: 50 * i));
        #endregion

        #region Skill
        SkillDatas.Add(0, new SkillData(id: 0, name: "EnergyBolt", shotCount:1 , speed: 3.0f, scala: 1.5f, shotTime: 0.2f, coolTime: 0.2f, lifeTime: 5.0f, animationName: "EnergyBoltAni",
            new Dictionary<int, SkillInfo>() { { 1, new SkillInfo(level: 1, damage: 1.0f) }, { 2, new SkillInfo(level: 2, damage: 1.0f) } }));//EnergyBolt
        SkillDatas.Add(1, new SkillData(id: 1, name: "EnergyBolt2", shotCount: 6, speed: 2.0f, scala: 1.5f, shotTime: 0.1f, coolTime: 2.0f, lifeTime: 5.0f, animationName: "EnergyBolt2Ani",
            new Dictionary<int, SkillInfo>() { { 1, new SkillInfo(level: 1, damage: 40.0f) }, { 2, new SkillInfo(level: 2, damage: 1.0f) } }));
        SkillDatas.Add(2, new SkillData(id: 2, name: "", shotCount: 2, speed: 50.0f, scala: 1, shotTime: 0.2f, coolTime: 0.5f, lifeTime: 5.0f, animationName: "SkillIcon_03Ani",
            new Dictionary<int, SkillInfo>() { { 1, new SkillInfo(level: 1, damage: 50.0f) }, { 2, new SkillInfo(level: 2, damage: 1.0f) } }));
        SkillDatas.Add(3, new SkillData(id: 3, name: "ElectricBolt", shotCount: 2, speed: 3.0f, scala: 2, shotTime: 0.2f, coolTime: 1.5f, lifeTime: 10.0f, animationName: "ElectricBoltAni",
            new Dictionary<int, SkillInfo>() { { 1, new SkillInfo(level: 1, damage: 3.0f) }, { 2, new SkillInfo(level: 2, damage: 1.0f) } }));//ElectricBolt
        SkillDatas.Add(4, new SkillData(id: 4, name: "", shotCount: 2, speed: 50.0f, scala: 1, shotTime: 0.2f, coolTime: 0.5f, lifeTime: 5.0f, animationName: "SkillIcon_05Ani",
            new Dictionary<int, SkillInfo>() { { 1, new SkillInfo(level: 1, damage: 70.0f) }, { 2, new SkillInfo(level: 2, damage: 1.0f) } }));
        SkillDatas.Add(5, new SkillData(id: 5, name: "", shotCount: 2, speed: 50.0f, scala: 1, shotTime: 0.2f, coolTime: 0.5f, lifeTime: 5.0f, animationName: "SkillIcon_06Ani",
            new Dictionary<int, SkillInfo>() { { 1, new SkillInfo(level: 1, damage: 80.0f) }, { 2, new SkillInfo(level: 2, damage: 1.0f) } }));
        SkillDatas.Add(6, new SkillData(id: 6, name: "", shotCount: 2, speed: 50.0f, scala: 1, shotTime: 0.2f, coolTime: 0.5f, lifeTime: 5.0f, animationName: "SkillIcon_07Ani",
            new Dictionary<int, SkillInfo>() { { 1, new SkillInfo(level: 1, damage: 90.0f) }, { 2, new SkillInfo(level: 2, damage: 1.0f) } }));
        SkillDatas.Add(7, new SkillData(id: 7, name: "", shotCount: 2, speed: 50.0f, scala: 1, shotTime: 0.2f, coolTime: 0.5f, lifeTime: 5.0f, animationName: "SkillIcon_08Ani", new Dictionary<int, SkillInfo>() { { 1, new SkillInfo(level: 1, damage: 100.0f) }, { 2, new SkillInfo(level: 2, damage: 1.0f) } }));
        SkillDatas.Add(8, new SkillData(id: 8, name: "TowEnergyShot", shotCount: 1, speed: 1.0f, scala: 3, shotTime: 0.5f, coolTime: 1.5f, lifeTime: 0.5f, animationName: "TowEnergyShot",
            new Dictionary<int, SkillInfo>() { { 1, new SkillInfo(level: 1, damage: 0.5f) }, { 2, new SkillInfo(level: 2, damage: 1.0f) } }));
        SkillDatas.Add(9, new SkillData(id: 9, name: "EnergyWave", shotCount: 4, speed: 1.0f, scala: 1, shotTime: 0.05f, coolTime: 2.0f, lifeTime: 5.0f, animationName: "EnergyWave",
            new Dictionary<int, SkillInfo>() { { 1, new SkillInfo(level: 1, damage: 0.5f) }, { 2, new SkillInfo(level: 2, damage: 1.0f) } }));

        #endregion

        #region Monster
        MonsterDatas.Add(0, new CreatureData(prefabId: 0, damage: 10, maxHp: 99999, hp: 99999, speed: 3.0f, exp: 9999, name: "Player", creatureSprite: "", creatureAnimator: ""));
        MonsterDatas.Add(1, new CreatureData(prefabId: 1, damage: 10, maxHp: 10, hp: 10, speed: 0.5f, exp: 1, name: "Zombe1", creatureSprite: "Monster_00.sprite", creatureAnimator: "Monster_00Animator.controller"));
        MonsterDatas.Add(2, new CreatureData(prefabId: 2, damage: 15, maxHp: 20, hp: 20, speed: 0.6f, exp: 2, name: "Zombe2", creatureSprite: "Monster_01.sprite", creatureAnimator: "Monster_01Animator.controller"));
        MonsterDatas.Add(3, new CreatureData(prefabId: 3, damage: 20, maxHp: 30, hp: 30, speed: 0.7f, exp: 3, name: "Skull1", creatureSprite: "Monster_02.sprite", creatureAnimator: "Monster_02Animator.controller"));
        MonsterDatas.Add(4, new CreatureData(prefabId: 4, damage: 25, maxHp: 40, hp: 40, speed: 0.8f, exp: 4, name: "Skull2", creatureSprite: "Monster_03.sprite", creatureAnimator: "Monster_03Animator.controller"));
        MonsterDatas.Add(5, new CreatureData(prefabId: 5, damage: 30, maxHp: 50, hp: 50, speed: 0.9f, exp: 5, name: "Devil1", creatureSprite: "Monster_04.sprite", creatureAnimator: "Monster_04Animator.controller"));
        #endregion

        #region SpriteDatas
        SpriteDatas.Add(0, new SprietData(id: 0, prefabString: "Stamina.sprite"));
        SpriteDatas.Add(1, new SprietData(id: 1, prefabString: "SilverExp.sprite"));
        SpriteDatas.Add(2, new SprietData(id: 2, prefabString: "GoldExp.sprite"));
        SpriteDatas.Add(3, new SprietData(id: 3, prefabString: "Gold.sprite"));
        SpriteDatas.Add(4, new SprietData(id: 4, prefabString: "Dia.sprite"));
        SpriteDatas.Add(5, new SprietData(id: 5, prefabString: "BronzeExp.sprite"));
        #endregion
    }
}
