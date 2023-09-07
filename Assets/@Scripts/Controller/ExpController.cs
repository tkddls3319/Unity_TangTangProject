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
                ExpAmount = 1;
                break;
            case GemType.Silver:
                ExpAmount = 5;
                break;
            case GemType.Gold:
                ExpAmount = 10;
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
            Vector3 target = gameObject.transform.position + dir * 1.5f;

            seqeu.Append(transform.DOMove(target, 0.3f).SetEase(Ease.Linear)).OnComplete(() =>
            {
                _coMoveToPlayer = StartCoroutine(CoMoveToPlayer());
            });
        }

    }
    public IEnumerator CoMoveToPlayer()
    {
        while (this.IsMyNotNullActive() == true)
        {
            Managers.Object.Dspawn(this);
            yield return new WaitForFixedUpdate();
        }
    }
}
