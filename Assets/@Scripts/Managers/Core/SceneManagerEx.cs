using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerEx
{
    public BaseScene CurrentScene { get { return GameObject.FindObjectOfType<BaseScene>(); } }
    public void LoadScene(Define.Scene type)
    {
        switch (CurrentScene.SceneType)
        {
            case Define.Scene.TitleScene:
                Managers.Clear();
                Time.timeScale = 1.0f;
                SceneManager.LoadScene(GetSceneName(type));
                break;
            case Define.Scene.LobbyScene:
                Managers.Clear();
                Time.timeScale = 1.0f;
                SceneManager.LoadScene(GetSceneName(type));
                break;
            case Define.Scene.MainScene:
                Managers.Clear();
                Time.timeScale = 1.0f;
                SceneManager.LoadScene(GetSceneName(type));
                break;
        }
    }
    string GetSceneName(Define.Scene type)
    {
        return Enum.GetName(typeof(Define.Scene), type);
    }

}
