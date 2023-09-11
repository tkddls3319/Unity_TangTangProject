using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_LobbyScene : UI_Scene
{
    enum Buttons
    {
        BtnStart
    }

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        Bind<Button>(typeof(Buttons));

        GetButton((int)Buttons.BtnStart).gameObject.BindEvent(() =>
        {
            Managers.Scene.LoadScene(Define.Scene.MainScene);

        });

        return true;
    }

}