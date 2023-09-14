using System.Collections;
using System.Collections.Generic;
using System.Xml.XPath;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UIElements;

public class DataManager
{
    public Dictionary<int, PlayerData> PlayerDatas { get; private set; } = new Dictionary<int, PlayerData>();
    public Dictionary<int, SkillData> SkillDatas { get; private set; } = new Dictionary<int, SkillData>();
    public Dictionary<int, CreatureData> MonsterDatas { get; private set; } = new Dictionary<int, CreatureData>();
    public Dictionary<int, SprietData> SpriteDatas { get; private set; } = new Dictionary<int, SprietData>();

    public void Init()
    {
        #region Player
        PlayerDatas.Add(1, new PlayerData(level: 1, maxExp: 50));
        PlayerDatas.Add(2, new PlayerData(level: 2, maxExp: 70));
        PlayerDatas.Add(3, new PlayerData(level: 3, maxExp: 110));
        PlayerDatas.Add(4, new PlayerData(level: 4, maxExp: 150));
        PlayerDatas.Add(5, new PlayerData(level: 5, maxExp: 200));
        PlayerDatas.Add(6, new PlayerData(level: 6, maxExp: 250));
        PlayerDatas.Add(7, new PlayerData(level: 7, maxExp: 350));
        PlayerDatas.Add(8, new PlayerData(level: 8, maxExp: 450));
        PlayerDatas.Add(9, new PlayerData(level: 9, maxExp: 550));
        #endregion

        //        public int Id;
        //public int Damage;
        //public float Scala;
        //public float CoolTime;
        //public float LifeTime;
        //public string AnimatorName;
        //public string AnimationName;

        #region Skill
        SkillDatas.Add(1, new SkillData(id: 1, damage: 1.0f, speed: 50.0f, scala: 1, coolTime: 0.5f, lifeTime: 1.0f, animatorName: "SkillAnimator.controller", animationName: "SkillIcon_01Ani")); ;
        SkillDatas.Add(2, new SkillData(id: 2, damage: 2.0f, speed: 30.0f, scala: 1.1f, coolTime: 0.1f, lifeTime: 1.2f, animatorName: "SkillAnimator.controller", animationName: "SkillIcon_02Ani"));
        SkillDatas.Add(3, new SkillData(id: 3, damage: 3.0f, speed: 50.0f, scala: 1.2f, coolTime: 0.2f, lifeTime: 1.4f, animatorName: "SkillAnimator.controller", animationName: "SkillIcon_03Ani"));
        SkillDatas.Add(4, new SkillData(id: 4, damage: 4.0f, speed: 30.0f, scala: 1.3f, coolTime: 0.3f, lifeTime: 1.6f, animatorName: "SkillAnimator.controller", animationName: "SkillIcon_04Ani"));
        SkillDatas.Add(5, new SkillData(id: 5, damage: 5.0f, speed: 50.0f, scala: 1.4f, coolTime: 0.4f, lifeTime: 1.8f, animatorName: "SkillAnimator.controller", animationName: "SkillIcon_05Ani"));
        SkillDatas.Add(6, new SkillData(id: 6, damage: 6.0f, speed: 30.0f, scala: 1.5f, coolTime: 0.5f, lifeTime: 2.0f, animatorName: "SkillAnimator.controller", animationName: "SkillIcon_06Ani"));
        SkillDatas.Add(7, new SkillData(id: 7, damage: 7.0f, speed: 50.0f, scala: 1.6f, coolTime: 0.6f, lifeTime: 2.2f, animatorName: "SkillAnimator.controller", animationName: "SkillIcon_07Ani"));
        SkillDatas.Add(8, new SkillData(id: 8, damage: 8.0f, speed: 30.0f, scala: 1.7f, coolTime: 0.7f, lifeTime: 2.4f, animatorName: "SkillAnimator.controller", animationName: "SkillIcon_08Ani"));
        SkillDatas.Add(9, new SkillData(id: 9, damage: 9.0f, speed: 50.0f, scala: 1.8f, coolTime: 0.8f, lifeTime: 2.6f, animatorName: "SkillAnimator.controller", animationName: "SkillIcon_09Ani"));
        SkillDatas.Add(10, new SkillData(id: 10, damage: 10.0f, speed: 30.0f, scala: 1.9f, coolTime: 0.9f, lifeTime: 2.8f, animatorName: "SkillAnimator.controller", animationName: "SkillIcon_10Ani"));
        #endregion

        #region Monster
        MonsterDatas.Add(0, new CreatureData(prefabId: 0, damage: 10, maxHp: 200, hp: 200, speed: 5.0f, exp: 9999, name: "Player", creatureSprite: "", creatureAnimator: ""));
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
