using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItemController : BaseController
{
    public float CollectDist { get; set; } = 4.0f;
    public Define.ObjectType ItemType;
    public override bool Init()
    {

        base.Init();

        return true;
    }

    public virtual void GetItem()
    {
        Managers.Game.Ground.Remove(this);
    }
}
