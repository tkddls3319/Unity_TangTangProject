using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UI_RewardPopup : UI_Popup
{
    enum GameObjects
    {
        Content,
        RewardItemScrollContentObject,
    }
    enum Buttons
    {
        BackgroundButton,
    }
    enum Text 
    {
        BackgroundText
    }


    string[] _spriteNames;
    int[] _numbers;

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        BindTMP_Text(typeof(Text)); 
        BindObject(typeof(GameObjects));
        BindButton(typeof(Buttons));

        GetButton((int)Buttons.BackgroundButton).gameObject.BindEvent(() =>
        {
            ClosePopupUI();
        });
        StartTextAnimation((int)Text.BackgroundText);

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


        GetObject((int)GameObjects.RewardItemScrollContentObject).DestroyChilds();
        for (int i = 0; i < _spriteNames.Length; i++)
        {
            UI_MaterialItem item = Managers.UI.MakeSubItem<UI_MaterialItem>(GetObject((int)GameObjects.RewardItemScrollContentObject).transform);
            item.SetInfo(_spriteNames[i], _numbers[i]);
        }
    }

    public override void ClosePopupUI()
    {
        Transform trans = GetObject((int)GameObjects.Content).transform;

        var seq = DOTween.Sequence();
        seq.Append(trans.DOScale(0.5f, 0.1f).SetEase(Ease.InOutBack).SetUpdate(true));
        seq.Append(trans.DOScale(0.1f, 0.1f).SetEase(Ease.InOutSine).SetUpdate(true));
        seq.Play().OnComplete(() =>
        {
            base.ClosePopupUI();
        });
    }
}
