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
    public enum ObjectType
    {
        Player,
        Monster,
        Exp,
        Bomb,
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
        Bullets,
        Bolt,
        Charged,
        Crossed,
        Hits1,
        Hits2,
        Hits3,
        Hits4,
        Hits5,
        Hits6,
        Pulse,
        Spark,
        WaveForm,
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
        Magnet,
        DropBox,
        Bomb
    }
}
