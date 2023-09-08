using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class BombController : DropItemController
{
    public override bool Init()
    {
        base.Init();

        return true;
    }

    public void SetInfo()
    {
    }

    public override void GetItem()
    {
        base.GetItem();
        if (_coroutine == null && this.IsMyNotNullActive())
        {
            //todo : 주석풀기
           // _coroutine = StartCoroutine(CoDefaultMoveToPlayer());
        }
    }

    public override void CompleteGetItem()
    {
        base.CompleteGetItem();

        //Managers.Object.KillALLMonster();
        //Managers.Object.Dspawn(this);
    }
}
