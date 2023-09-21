using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using Unity.VisualScripting;
using UnityEngine;

public class ExpInfo
{
    public enum GemType
    {
        Bronze,
        Silver,
        Gold
    }

    public GemType Type;
    public string SpriteName;
    public Vector3 ExpPos;
    public int ExpAmount;

    public ExpInfo(GemType type, Vector3 expPos)
    {
        Type = type;
        SpriteName = $"{type}Exp.sprite";
        ExpPos = expPos;

        switch (type)
        {
            case GemType.Bronze:
                ExpAmount = Define.BRONZE_EXP_AMOUNT;
                break;
            case GemType.Silver:
                ExpAmount = Define.SILVER_EXP_AMOUNT;
                break;
            case GemType.Gold:
                ExpAmount = Define.GOLD_EXP_AMOUNT;
                break;
        }
    }
}
public class ExpController : DropItemController
{
    ExpInfo _expInfo;
    Coroutine _coMoveToPlayer;
    public override bool Init()
    {
        base.Init();
        ItemType = Define.ObjectType.Exp;

        return true;
    }
    public override void CompleteGetItem()
    {
        base.CompleteGetItem();

        Managers.Game.Player.Exp += _expInfo.ExpAmount;
        Managers.Object.Dspawn(this);
    }

    public void SetInfo(ExpInfo expInfo)
    {
        _expInfo = expInfo;
        Sprite spr = Managers.Resource.Load<Sprite>($"{expInfo.SpriteName}");
        GetComponent<SpriteRenderer>().sprite = spr;
        transform.localScale = _expInfo.ExpPos;
    }

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

