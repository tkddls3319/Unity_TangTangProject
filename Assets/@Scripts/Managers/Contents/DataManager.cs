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
        LevelDatas.Add(1, new LevelData(level: 1, maxExp: 50));
        LevelDatas.Add(2, new LevelData(level: 2, maxExp: 70));
        LevelDatas.Add(3, new LevelData(level: 3, maxExp: 110));
        LevelDatas.Add(4, new LevelData(level: 4, maxExp: 150));
        LevelDatas.Add(5, new LevelData(level: 5, maxExp: 200));
        LevelDatas.Add(6, new LevelData(level: 6, maxExp: 250));
        LevelDatas.Add(7, new LevelData(level: 7, maxExp: 350));
        LevelDatas.Add(8, new LevelData(level: 8, maxExp: 450));
        LevelDatas.Add(9, new LevelData(level: 9, maxExp: 550));
        #endregion

        //public int Id;
        //public int Damage;
        //public float Scala;
        //public float CoolTime;
        //public float LifeTime;
        //public string AnimatorName;
        //public string AnimationName;

        #region Skill
        SkillDatas.Add(0, new SkillData(id: 0, name: "EnergyBolt", speed: 10.0f, scala: 1.5f, coolTime: 0.5f, lifeTime: 5.0f, animatorName: "SkillAnimator.controller", animationName: "EnergyBoltAni", new Dictionary<int, SkillInfo>()
        { { 1, new SkillInfo(level: 1, damage: 3.0f) }, { 2, new SkillInfo(level: 2, damage: 1.0f) } }));//EnergyBolt
        SkillDatas.Add(1, new SkillData(id: 1, name: "", speed: 50.0f, scala: 1, coolTime: 0.5f, lifeTime: 5.0f, animatorName: "SkillAnimator.controller", animationName: "SkillIcon_02Ani", new Dictionary<int, SkillInfo>() { { 1, new SkillInfo(level: 1, damage: 40.0f) }, { 2, new SkillInfo(level: 2, damage: 1.0f) } }));
        SkillDatas.Add(2, new SkillData(id: 2, name: "", speed: 50.0f, scala: 1, coolTime: 0.5f, lifeTime: 5.0f, animatorName: "SkillAnimator.controller", animationName: "SkillIcon_03Ani", new Dictionary<int, SkillInfo>() { { 1, new SkillInfo(level: 1, damage: 50.0f) }, { 2, new SkillInfo(level: 2, damage: 1.0f) } }));
        SkillDatas.Add(3, new SkillData(id: 3, name: "ElectricBolt", speed: 5.0f, scala: 3, coolTime: 1.5f, lifeTime: 10.0f, animatorName: "SkillAnimator.controller", animationName: "ElectricBoltAni", new Dictionary<int, SkillInfo>() { { 1, new SkillInfo(level: 1, damage: 10.0f) }, { 2, new SkillInfo(level: 2, damage: 1.0f) } }));//ElectricBolt
        SkillDatas.Add(4, new SkillData(id: 4, name: "", speed: 50.0f, scala: 1, coolTime: 0.5f, lifeTime: 5.0f, animatorName: "SkillAnimator.controller", animationName: "SkillIcon_05Ani", new Dictionary<int, SkillInfo>() { { 1, new SkillInfo(level: 1, damage: 70.0f) }, { 2, new SkillInfo(level: 2, damage: 1.0f) } }));
        SkillDatas.Add(5, new SkillData(id: 5, name: "", speed: 50.0f, scala: 1, coolTime: 0.5f, lifeTime: 5.0f, animatorName: "SkillAnimator.controller", animationName: "SkillIcon_06Ani", new Dictionary<int, SkillInfo>() { { 1, new SkillInfo(level: 1, damage: 80.0f) }, { 2, new SkillInfo(level: 2, damage: 1.0f) } }));
        SkillDatas.Add(6, new SkillData(id: 6, name: "", speed: 50.0f, scala: 1, coolTime: 0.5f, lifeTime: 5.0f, animatorName: "SkillAnimator.controller", animationName: "SkillIcon_07Ani", new Dictionary<int, SkillInfo>() { { 1, new SkillInfo(level: 1, damage: 90.0f) }, { 2, new SkillInfo(level: 2, damage: 1.0f) } }));
        SkillDatas.Add(7, new SkillData(id: 7, name: "", speed: 50.0f, scala: 1, coolTime: 0.5f, lifeTime: 5.0f, animatorName: "SkillAnimator.controller", animationName: "SkillIcon_08Ani", new Dictionary<int, SkillInfo>() { { 1, new SkillInfo(level: 1, damage: 100.0f) }, { 2, new SkillInfo(level: 2, damage: 1.0f) } }));
        SkillDatas.Add(8, new SkillData(id: 8, name: "", speed: 50.0f, scala: 1, coolTime: 0.5f, lifeTime: 5.0f, animatorName: "SkillAnimator.controller", animationName: "SkillIcon_09Ani", new Dictionary<int, SkillInfo>() { { 1, new SkillInfo(level: 1, damage: 110.0f) }, { 2, new SkillInfo(level: 2, damage: 1.0f) } }));
        #endregion

        #region Monster
        MonsterDatas.Add(0, new CreatureData(prefabId: 0, damage: 10, maxHp: 1000, hp: 1000, speed: 5.0f, exp: 9999, name: "Player", creatureSprite: "", creatureAnimator: ""));
        MonsterDatas.Add(1, new CreatureData(prefabId: 1, damage: 10, maxHp: 10, hp: 10, speed: 1.0f, exp: 1, name: "Zombe1", creatureSprite: "Monster_00.sprite", creatureAnimator: "Monster_00Animator.controller"));
        MonsterDatas.Add(2, new CreatureData(prefabId: 2, damage: 15, maxHp: 20, hp: 20, speed: 1.2f, exp: 2, name: "Zombe2", creatureSprite: "Monster_01.sprite", creatureAnimator: "Monster_01Animator.controller"));
        MonsterDatas.Add(3, new CreatureData(prefabId: 3, damage: 20, maxHp: 30, hp: 30, speed: 1.5f, exp: 3, name: "Skull1", creatureSprite: "Monster_02.sprite", creatureAnimator: "Monster_02Animator.controller"));
        MonsterDatas.Add(4, new CreatureData(prefabId: 4, damage: 25, maxHp: 40, hp: 40, speed: 1.7f, exp: 4, name: "Skull2", creatureSprite: "Monster_03.sprite", creatureAnimator: "Monster_03Animator.controller"));
        MonsterDatas.Add(5, new CreatureData(prefabId: 5, damage: 30, maxHp: 50, hp: 50, speed: 2.0f, exp: 5, name: "Devil1", creatureSprite: "Monster_04.sprite", creatureAnimator: "Monster_04Animator.controller"));
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
