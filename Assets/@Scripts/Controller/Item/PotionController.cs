using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionController : DropItemController
{
    Coroutine _coMoveToPlayer;
    public override bool Init()
    {
        base.Init();
        ItemType = Define.ObjectType.Potion;
        return true;
    }

    public void SetInfo() { }
    public override void GetItem()
    {
        base.GetItem();
        if (_coMoveToPlayer == null && this.IsMyNotNullActive())
        {
            DG.Tweening.Sequence seqeu = DOTween.Sequence();
            Vector3 dir = (transform.position - Managers.Game.Player.PlayerCenterPos).normalized;
            Vector3 target = gameObject.transform.position + dir * 1.0f;

            seqeu.Append(transform.DOMove(target, 0.2f).SetEase(Ease.Linear)).OnComplete(() =>
            {
                _coMoveToPlayer = StartCoroutine(CoMoveToPlayer());
            });
        }
    }
    public override void CompleteGetItem()
    {
        base.CompleteGetItem();

        Managers.Game.Player.Healing();
        Managers.Object.Dspawn(this);
    }
    public IEnumerator CoMoveToPlayer()
    {
        while (this.IsMyNotNullActive() == true)
        {
            float dist = Vector3.Distance(gameObject.transform.position, Managers.Game.Player.PlayerCenterPos);
            transform.position = Vector3.MoveTowards(transform.position, Managers.Game.Player.PlayerCenterPos, Time.deltaTime * 30.0f);

            if (dist < 0.1f)
            {
                CompleteGetItem();
                yield break;
            }

            yield return new WaitForFixedUpdate();
        }
    }
    public override void OnDisable()
    {
        base.OnDisable();

        if (_coMoveToPlayer != null)
        {
            StopCoroutine(_coMoveToPlayer);
            _coMoveToPlayer = null;
        }
    }
}
