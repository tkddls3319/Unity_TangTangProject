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

        GetButton((int)Buttons.BtnBolt).gameObject.BindEvent(() =>
        {
            Managers.Game.Player.SkillID = Define.SkillType.EnergyBolt;
        });
        GetButton((int)Buttons.BtnCharged).gameObject.BindEvent(() =>
        {
            Managers.Game.Player.SkillID = Define.SkillType.Charged;

        }); 
        GetButton((int)Buttons.BtnCrossed).gameObject.BindEvent(() =>
        {
            Managers.Game.Player.SkillID = Define.SkillType.Crossed;
        }); 
        GetButton((int)Buttons.BtnHits1).gameObject.BindEvent(() =>
        {
            Managers.Game.Player.SkillID = Define.SkillType.Hits1;
        }); 
        GetButton((int)Buttons.BtnHits2).gameObject.BindEvent(() =>
        {
            Managers.Game.Player.SkillID = Define.SkillType.Hits2;
        }); 
        GetButton((int)Buttons.BtnHits3).gameObject.BindEvent(() =>
        {
            Managers.Game.Player.SkillID = Define.SkillType.Hits3;
        }); 
        GetButton((int)Buttons.BtnHits4).gameObject.BindEvent(() =>
        {
            Managers.Game.Player.SkillID = Define.SkillType.Hits4;
        }); 
        GetButton((int)Buttons.BtnHits5).gameObject.BindEvent(() =>
        {
            Managers.Game.Player.SkillID = Define.SkillType.Hits5;
        }); 
        GetButton((int)Buttons.BtnHits6).gameObject.BindEvent(() =>
        {
            Managers.Game.Player.SkillID = Define.SkillType.Hits6;
        }); 
        GetButton((int)Buttons.BtnPulse).gameObject.BindEvent(() =>
        {
            Managers.Game.Player.SkillID = Define.SkillType.Pulse;
        }); 
        GetButton((int)Buttons.BtnSpark).gameObject.BindEvent(() =>
        {
            Managers.Game.Player.SkillID = Define.SkillType.Spark;

        }); 
        GetButton((int)Buttons.BtnWaveForm).gameObject.BindEvent(() =>
        {
            Managers.Game.Player.SkillID = Define.SkillType.WaveForm;

        }); 
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
