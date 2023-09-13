using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UI_LobbyScene : UI_Scene
{
    enum Texts
    {
        StaminaText,
        DiaText,
        GoldText,
    }
    enum Buttons
    {
        StaminaPlusButton,
    }

    UI_RewardPopup _rewardPopupUI;
    public UI_RewardPopup RewardPopupUI { get { return _rewardPopupUI; } }

    UI_BattlePop _battlePopUI;

    private void OnDestroy()
    {
        if (Managers.Game != null)
            Managers.Game.OnResourcesChagned -= OnResourcesChagned;
    }

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        BindButton(typeof(Buttons));
        BindTMP_Text(typeof(Texts));

        GetButton((int)Buttons.StaminaPlusButton).gameObject.BindEvent(() =>
        {
            Managers.UI.ShowPopupUI<UI_StaminaChargePopup>();
        });
        GetButton((int)Buttons.StaminaPlusButton).gameObject.GetOrAddComponent<UI_ButtonAnimation>();

        #region ÆË¾÷ ¼¼ÆÃ
        _battlePopUI = Managers.UI.ShowPopupUI<UI_BattlePop>();
        _rewardPopupUI = Managers.UI.ShowPopupUI<UI_RewardPopup>();
        PopupInit();
        #endregion

        Managers.Game.OnResourcesChagned += OnResourcesChagned;
        OnResourcesChagned();
        return true;
    }

    void PopupInit()
    {
        _rewardPopupUI.gameObject.SetActive(false);
    }
    void OnResourcesChagned()
    {
        GetTMP_Text((int)Texts.StaminaText).text = $"{Managers.Game.Stamina}/{Define.MAX_STAMINA}";
        GetTMP_Text((int)Texts.DiaText).text = $"{Managers.Game.Dia}";
        GetTMP_Text((int)Texts.GoldText).text = $"{Managers.Game.Gold}";
    }
}