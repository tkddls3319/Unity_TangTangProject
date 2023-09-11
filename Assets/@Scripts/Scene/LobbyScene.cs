using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyScene : BaseScene
{
    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.LobbyScene;

        Managers.Resource.LoadAllAsync<Object>("LoadPrefab", (key, count, totalCount) =>
        {
            if (count == totalCount)
                LoadStage();
        });
    }

    void LoadStage()
    {
        Managers.UI.ShowSceneUI<UI_LobbyScene>();
    }

    public override void Clear()
    {
    }
}
