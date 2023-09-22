using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Define
{
    public const int MAX_STAMINA = 50;
    public const int SUB_STAMINA = 3;

    #region º¸¼® °æÇèÄ¡ È¹µæ·®
    public const int BRONZE_EXP_AMOUNT = 1;
    public const int SILVER_EXP_AMOUNT = 2;
    public const int GOLD_EXP_AMOUNT = 5;
    #endregion

    #region SpriteID
    public const int STAMINA_ID = 0;

    #endregion


    public enum ObjectType
    {
        Player,
        Monster,
        Exp,
        Bomb,
        Potion,
    }

    public enum UIEvent
    {
        Click,
        Preseed,
        PointerDown,
        PointerUp,
        Enter,
        Exit,

        Move,
        Drag,
        BeginDrag,
        EndDrag,
    }

    public enum Exp
    {
        ExpBronze,
        ExpSilver,
        ExpGold,
    }

    public enum SkillType
    {
        EnergyBolt = 0,
        EnergyBolt2 =1,
        ElectricBolt = 3,
        TowEnergyShot = 8,
        EnergyWave = 9,
    }
    public enum CreatureState
    {
        Idle,
        Moving,
        Skill,
        Hit,
        Dead,
    }

    public enum Scene
    {
        Unknown,
        TitleScene,
        LobbyScene,
        GameScene,
    }

    public enum DropItemType
    {
        Potion,
        Bomb,
        Magnet,
        DropBox,
    }
}
