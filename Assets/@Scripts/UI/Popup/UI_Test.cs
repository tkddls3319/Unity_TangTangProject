using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UI_Test : UI_Popup
{
    enum Buttons
    {
        Btn,
    }
    void Start()
    {
        Bind<Button>(typeof(Buttons));
    }
}
