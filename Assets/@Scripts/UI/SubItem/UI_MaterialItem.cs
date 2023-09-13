using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class UI_MaterialItem : UI_Base
{

    enum Images
    {
        MaterialItemImage
    }
    enum Texts 
    {
        MaterialItemText,
    }

    private void Awake()
    {
        Init();
    }
    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        BindImage(typeof(Images));
        BindTMP_Text(typeof(Texts));


        return true;
    }

    public void SetInfo(string spriteName, int number)
    {
        transform.localScale = Vector3.one;
        GetImage((int)Images.MaterialItemImage).sprite = Managers.Resource.Load<Sprite>(spriteName);
        GetTMP_Text((int)Texts.MaterialItemText).text = $"{number}";
    }
}
