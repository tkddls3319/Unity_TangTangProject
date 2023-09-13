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
        BtnStart
    }

    UI_RewardPopup _rewardPopupUI;
    public UI_RewardPopup RewardPopupUI { get { return _rewardPopupUI; } }

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

        GetButton((int)Buttons.BtnStart).gameObject.BindEvent(() =>
        {
            if (Managers.Game.Stamina < Define.SUB_STAMINA)
            {
                Managers.UI.ShowPopupUI<UI_StaminaChargePopup>();
                return;
            }

            Managers.Game.Stamina -= Define.SUB_STAMINA;
            Managers.Scene.LoadScene(Define.Scene.GameScene);
        });
        GetButton((int)Buttons.BtnStart).gameObject.GetOrAddComponent<UI_ButtonAnimation>();

        GetButton((int)Buttons.StaminaPlusButton).gameObject.BindEvent(() =>
        {
            Managers.UI.ShowPopupUI<UI_StaminaChargePopup>();
        });
        GetButton((int)Buttons.StaminaPlusButton).gameObject.GetOrAddComponent<UI_ButtonAnimation>();

        _rewardPopupUI = Managers.UI.ShowPopupUI<UI_RewardPopup>();
        PopupInit();

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