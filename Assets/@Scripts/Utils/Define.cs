using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Define
{

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
        Down,
        Move,
        Enter,
        Exit
    }

    public enum Exp
    {
        ExpBronze,
        ExpSilver,
        ExpGold,
    }

    public enum Projectile
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
        MainScene,
    }

    public enum DropItemType
    {
        Potion,
        Magnet,
        DropBox,
        Bomb
    }
}
