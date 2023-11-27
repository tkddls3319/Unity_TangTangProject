using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class UI_SkillUp : UI_Popup
{
    enum Texts
    {
        SkillText_1,
        SkillText_2,
        SkillText_3,
        BeforLevelText,
        AfterLevelText
    }
    enum Buttons
    {
        SkillButton_1,
        SkillButton_2,
        SkillButton_3,
        CardRefreshButton
    }
    enum Images
    {
        SkillImage1,
        SkillImage2,
        SkillImage3,
    }
    List<int> _randomIdxs = new List<int>();
    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        BindTMP_Text(typeof(Texts));
        BindButton(typeof(Buttons));
        BindImage(typeof(Images));


        GetButton((int)Buttons.SkillButton_1).gameObject.BindEvent(() =>
        {
            LevelUpClick(_randomIdxs[0]);
        });
        GetButton((int)Buttons.SkillButton_2).gameObject.BindEvent(() =>
        {
            LevelUpClick(_randomIdxs[1]);
        });
        GetButton((int)Buttons.SkillButton_3).gameObject.BindEvent(() =>
        {
            LevelUpClick(_randomIdxs[2]);
        });

        Refresh();

        for (int i = 0; i < 3; i++)
            _randomIdxs.Add(UnityEngine.Random.Range(0, 5));

        SkillCardChange(_randomIdxs);

        return true;
    }

    void SkillCardChange(List<int> randomIdxs)
    {
        for (int i = 0; i < randomIdxs.Count; i++)
        {
            string skillName = Enum.GetName(typeof(Define.SkillType), randomIdxs[i]);
            GetImage(i).sprite = Managers.Resource.Load<Sprite>($"{skillName}.sprite");
        }
    }
    void LevelUpClick(int number)
    {
        string skillName = Enum.GetName(typeof(Define.SkillType), number);
        Define.SkillType myenum = (Define.SkillType)Enum.Parse(typeof(Define.SkillType), skillName);
        Managers.Game.Player.Skills.LevelUpSkill(myenum);

        ClosePopupUI();
    }
    void Refresh()
    {
        GetTMP_Text((int)Texts.BeforLevelText).text = $"Lv.{Managers.Game.Player.Level - 1}";
        GetTMP_Text((int)Texts.AfterLevelText).text = $"Lv.{Managers.Game.Player.Level}";
    }

    public override void ClosePopupUI()
    {
        //Transform trans = GetObject((int)GameObjects.Content).transform;

        //var seq = DOTween.Sequence();
        //seq.Append(trans.DOScale(0.5f, 0.1f).SetEase(Ease.InOutBack).SetUpdate(true));
        //seq.Append(trans.DOScale(0.1f, 0.1f).SetEase(Ease.InOutSine).SetUpdate(true));
        //seq.Play().OnComplete(() =>
        //{
        //    gameObject.SetActive(false);
        //});

        Managers.UI.ClosePopupUI(this);
    }
}
