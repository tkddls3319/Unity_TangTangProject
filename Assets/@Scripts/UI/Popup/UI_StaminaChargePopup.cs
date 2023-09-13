using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class UI_StaminaChargePopup : UI_Popup
{

    enum GameObejcts
    {
        Content
    }
    enum Buttons
    {
        BackgroundButton,
        BuyButton
    }
    enum Text
    {
        BackgroundText
    }

    public override bool Init()
    {
        if(base.Init() == false)
            return false;

        BindTMP_Text(typeof(Text));
        BindObject(typeof(GameObejcts));
        BindButton(typeof(Buttons));

        GetButton((int)Buttons.BackgroundButton).gameObject.BindEvent(() =>
        {
            ClosePopupUI();
        });
        GetButton((int)Buttons.BackgroundButton).gameObject.GetOrAddComponent<UI_ButtonAnimation>();

        GetButton((int)Buttons.BuyButton).gameObject.BindEvent(() =>
        {
            if (Managers.Game.Dia >= 100)
            {
                string[] spriteNames = new string[1];
                int[] numbers = new int[1];

                spriteNames[0] = Managers.Data.SpriteDatas[Define.STAMINA_ID].PrefabString;
                numbers[0] = 15;

                UI_RewardPopup rewardPopup = (Managers.UI.SceneUI as UI_LobbyScene).RewardPopupUI;
                rewardPopup.gameObject.SetActive(true);

                Managers.Game.Dia -= 100;
                Managers.Game.Stamina += 15;

                rewardPopup.SetInfo(spriteNames, numbers);
            }
        });

        StartTextAnimation((int)Text.BackgroundText);

        return true;
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
