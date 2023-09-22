using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class UI_GameScene : UI_Scene
{
    enum Buttons
    {
        BtnBolt,
        BtnCharged,
        BtnCrossed,
        BtnHits1,
        BtnHits2,
        BtnHits3,
        BtnHits4,
        BtnHits5,
        BtnHits6,
        BtnPulse,
        BtnSpark,
        BtnWaveForm,
    }
    enum GameObjects
    {
        ExpBar,
            EffectFlash
    }
    enum Texts
    {
        KillValueText,
        LevelValueText
    }
    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        #region Bind
        Bind<Button>(typeof(Buttons));
        Bind<GameObject>(typeof(GameObjects));
        Bind<TMP_Text>(typeof(Texts));
   
        #endregion

        Managers.Game.Player.OnPlayerDataUpdated += OnPlayerDataUpdated;

        return true;
    }

    private void OnPlayerDataUpdated()
    {
        GetObject((int)GameObjects.ExpBar).GetComponent<Slider>().value = Managers.Game.Player.Exp;
        GetTMP_Text((int)Texts.KillValueText).text = $"{Managers.Game.Player.KillCount}";
        GetTMP_Text((int)Texts.LevelValueText).text = $"{Managers.Game.Player.Level}";
    }


    public void EffectFlash()
    {
        StartCoroutine(CoEffectFlash());
    }
    IEnumerator CoEffectFlash()
    {
        Color color = Color.red;

        yield return null;

        Sequence seq = DOTween.Sequence();

        seq.Append(GetObject((int)GameObjects.EffectFlash).GetComponent<Image>().DOFade(1, 0.1f))
            .Append(GetObject((int)GameObjects.EffectFlash).GetComponent<Image>().DOFade(0, 0.2f))
            .OnComplete(() => { });
    }
}
