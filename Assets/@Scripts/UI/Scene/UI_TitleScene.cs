using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_TitleScene : UI_Scene
{
    enum GameObjects
    {
        Slider,
    }
    enum Buttons
    {
        StartButton
    }
    enum TMP_Texts
    {
        TitleText3
    }

    bool isPreload = false;
    public override bool Init()
    {
        base.Init();

        BindObject(typeof(GameObjects));
        BindButton(typeof(Buttons));
        BindTMP_Text(typeof(TMP_Texts));

        GetObject((int)GameObjects.Slider).GetComponent<Slider>().value = 0;
        GetButton((int)Buttons.StartButton).gameObject.BindEvent(() =>
        {
            if (isPreload)
                Managers.Scene.LoadScene(Define.Scene.LobbyScene);
        });
        GetButton((int)Buttons.StartButton).gameObject.SetActive(false);

        return true;
    }
    private void Awake()
    {
        Init();
    }
    private void Start()
    {
        Managers.Resource.LoadAllAsync<Object>("LoadPrefab", (key, count, totalCount) =>
        {
            GetObject((int)GameObjects.Slider).GetComponent<Slider>().value = (float)count / totalCount;
            if (count == totalCount)
            {
                isPreload = true;
                GetButton((int)Buttons.StartButton).gameObject.SetActive(true);
                Managers.Data.Init();
                Managers.Game.Init();
                StartButtonAnimation();
            }
        });
    }
    void StartButtonAnimation()
    {
        GetTMP_Text((int)TMP_Texts.TitleText3).DOFade(0, 1f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutCubic).Play();
    }
}
