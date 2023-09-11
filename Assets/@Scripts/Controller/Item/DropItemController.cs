using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItemController : BaseController
{
    public float CollectDist { get; set; } = 4.0f;
    public Define.ObjectType ItemType;
    public Coroutine _coroutine;
    public override bool Init()
    {
        base.Init();

        return true;
    }

    public virtual void GetItem()
    {
        Managers.Game.Ground.Remove(this);
    }

    public IEnumerator CoDefaultMoveToPlayer()
    {
        while (this.IsMyNotNullActive() == true)
        {
            float dist = Vector3.Distance(gameObject.transform.position, Managers.Game.Player.transform.position);

            if (dist < 0.3f)
            {
                CompleteGetItem();
                yield break;
            }
            yield return new WaitForFixedUpdate();
        }
    }

    public virtual void CompleteGetItem()
    {
    }
    virtual public void OnDisable()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }
}
