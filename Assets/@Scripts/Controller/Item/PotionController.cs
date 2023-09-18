using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionController : DropItemController
{
    public override bool Init()
    {
        return base.Init();
    }

    public void SetInfo() { }
    public override void GetItem()
    {
        base.GetItem();
        if (_coroutine == null && this.IsMyNotNullActive())
        {
            _coroutine = StartCoroutine(CoDefaultMoveToPlayer());
        }
    }
    public override void CompleteGetItem()
    {
        base.CompleteGetItem();

        Managers.Game.Player.Healing();

        Managers.Object.Dspawn(this);
    }
}
