using System.Collections;
using System.Collections.Generic;
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
        ExpBar
    }
    public override bool Init()
    {

        Bind<Button>(typeof(Buttons));
        Bind<GameObject>(typeof(GameObjects));

        GetButton((int)Buttons.BtnBolt).gameObject.BindEvent(() =>
        {
            Managers.Game.Player.SkillID = Define.Projectile.Bolt;
        });
        GetButton((int)Buttons.BtnCharged).gameObject.BindEvent(() =>
        {
            Managers.Game.Player.SkillID = Define.Projectile.Charged;

        }); ;
        GetButton((int)Buttons.BtnCrossed).gameObject.BindEvent(() =>
        {
            Managers.Game.Player.SkillID = Define.Projectile.Crossed;
        }); ;
        GetButton((int)Buttons.BtnHits1).gameObject.BindEvent(() =>
        {
            Managers.Game.Player.SkillID = Define.Projectile.Hits1;
        }); ;
        GetButton((int)Buttons.BtnHits2).gameObject.BindEvent(() =>
        {
            Managers.Game.Player.SkillID = Define.Projectile.Hits2;
        }); ;
        GetButton((int)Buttons.BtnHits3).gameObject.BindEvent(() =>
        {
            Managers.Game.Player.SkillID = Define.Projectile.Hits3;
        }); ;
        GetButton((int)Buttons.BtnHits4).gameObject.BindEvent(() =>
        {
            Managers.Game.Player.SkillID = Define.Projectile.Hits4;
        }); ;
        GetButton((int)Buttons.BtnHits5).gameObject.BindEvent(() =>
        {
            Managers.Game.Player.SkillID = Define.Projectile.Hits5;
        }); ;
        GetButton((int)Buttons.BtnHits6).gameObject.BindEvent(() =>
        {
            Managers.Game.Player.SkillID = Define.Projectile.Hits6;
        }); ;
        GetButton((int)Buttons.BtnPulse).gameObject.BindEvent(() =>
        {
            Managers.Game.Player.SkillID = Define.Projectile.Pulse;
        }); ;
        GetButton((int)Buttons.BtnSpark).gameObject.BindEvent(() =>
        {
            Managers.Game.Player.SkillID = Define.Projectile.Spark;

        }); ;
        GetButton((int)Buttons.BtnWaveForm).gameObject.BindEvent(() =>
        {
            Managers.Game.Player.SkillID = Define.Projectile.WaveForm;

        }); ;



        return base.Init();
    }

    private void LateUpdate()
    {
        SetHpRatio(1);
    }

    public void SetHpRatio(float ratio)
    {
        GetObject((int)GameObjects.ExpBar).GetComponent<Slider>().value += ratio;
    }

}
