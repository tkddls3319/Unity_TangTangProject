using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_SkillClickScene : UI_Scene
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

    public override bool Init()
    {

        Bind<Button>(typeof(Buttons));

        GetButton((int)Buttons.BtnBolt).gameObject.BindEvent(() =>
        {
            Managers.Object.Player.SkillID = Define.Projectile.Bolt;
        });
        GetButton((int)Buttons.BtnCharged).gameObject.BindEvent(() =>
        {
            Managers.Object.Player.SkillID = Define.Projectile.Charged;

        });;
        GetButton((int)Buttons.BtnCrossed).gameObject.BindEvent(() =>
        {

        }); ;
        GetButton((int)Buttons.BtnHits1).gameObject.BindEvent(() =>
        {

        });;
        GetButton((int)Buttons.BtnHits2).gameObject.BindEvent(() =>
        {

        });;
        GetButton((int)Buttons.BtnHits3).gameObject.BindEvent(() =>
        {

        });;
        GetButton((int)Buttons.BtnHits4).gameObject.BindEvent(() =>
        {

        });;
        GetButton((int)Buttons.BtnHits5).gameObject.BindEvent(() =>
        {

        });;
        GetButton((int)Buttons.BtnHits6).gameObject.BindEvent(() =>
        {

        });;
        GetButton((int)Buttons.BtnPulse).gameObject.BindEvent(() =>
        {

        });;
        GetButton((int)Buttons.BtnSpark).gameObject.BindEvent(() =>
        {

        }); ;
        GetButton((int)Buttons.BtnWaveForm).gameObject.BindEvent(() =>
        {

        }); ;



        return base.Init();
    }


}
