using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UI_BattlePop : UI_Popup
{
    enum Buttons
    {
        GameStartButton
    }
    public override bool Init()
    {
        if(base.Init() == false)
            return false;

        BindButton(typeof(Buttons));

        GetButton((int)Buttons.GameStartButton).gameObject.BindEvent(() =>
        {
            if (Managers.Game.Stamina < Define.SUB_STAMINA)
            {
                Managers.UI.ShowPopupUI<UI_StaminaChargePopup>();
                return;
            }

            Managers.Game.Stamina -= Define.SUB_STAMINA;
            Managers.Scene.LoadScene(Define.Scene.GameScene);
        });
        GetButton((int)Buttons.GameStartButton).gameObject.GetOrAddComponent<UI_ButtonAnimation>();

        return true;
    }
}
