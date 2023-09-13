using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_RewardPopup : UI_Popup
{
    enum GameObejcts
    {
        Content
    }
    enum Buttons
    {
        BackgroundButton,
    }

    string[] _spriteNames;
    int[] _numbers;

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        BindObject(typeof(GameObejcts));
        BindButton(typeof(Buttons));

        GetButton((int)Buttons.BackgroundButton).gameObject.BindEvent(() =>
        {
            ClosePopupUI();
        });

        RefreshUI();

        return true;
    }

    public void SetInfo(string[] spriteNames, int[] numbers)
    {
        _spriteNames = spriteNames;
        _numbers = numbers;
        RefreshUI();
    }

    void RefreshUI()
    {
        if (_init == false)
            return;


        //GetObject((int)GameObjects.RewardItemScrollContentObject).DestroyChilds();
        //for (int i = 0; i < _spriteName.Length; i++)
        //{
        //    Debug.Log(_spriteName[i]);
        //    UI_MaterialItem item = Managers.UI.MakeSubItem<UI_MaterialItem>(GetObject((int)GameObjects.RewardItemScrollContentObject).transform);
        //    item.SetInfo(_spriteName[i], _count[i]);
        //}

    }



    public override void ClosePopupUI()
    {
        Transform trans = GetObject((int)GameObejcts.Content).transform;

        var seq = DOTween.Sequence();
        seq.Append(trans.DOScale(0.5f, 0.1f).SetEase(Ease.InOutBack).SetUpdate(true));
        seq.Append(trans.DOScale(0.1f, 0.1f).SetEase(Ease.InOutSine).SetUpdate(true));
        seq.Play().OnComplete(() =>
        {
            base.ClosePopupUI();
        });
    }
}
