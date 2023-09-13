using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager
{
    int _order = 20;
    public UI_Scene SceneUI { get; private set; }
    public UI_Base JoystickUI { get; private set; }
    Stack<UI_Popup> _popups = new Stack<UI_Popup>();

    public GameObject Root
    {
        get
        {
            GameObject root = GameObject.Find("@UI_Root");
            if (root == null)
                root = new GameObject() { name = "@UI_Root" };

            return root;
        }
    }

    public void SetCanvas(GameObject go, bool sort = true)
    {
        Canvas canvas = go.GetOrAddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.overrideSorting = true;

        if (sort)
        {
            canvas.sortingOrder = _order;
            _order++;
        }
        else
        {
            canvas.sortingOrder = 0;
        }
    }
    public void ShowJoyStick()
    {
        GameObject go = Managers.Resource.Instantiate($"UI_Joystick.prefab");
    }

    public void ShowSceneUI<T>(string key = null) where T : UI_Scene
    {
        if (string.IsNullOrEmpty(key))
            key = typeof(T).Name;


        GameObject go = Managers.Resource.Instantiate($"{key}.prefab");

        T sceneUI = go.GetOrAddComponent<T>();
        SceneUI = sceneUI;
    }
    public T ShowPopupUI<T>(string key = null) where T : UI_Popup
    {
        if (string.IsNullOrEmpty(key))
            key = typeof(T).Name;


        UI_Popup popup = _popups.FirstOrDefault(f => f.name == key);

        if (popup != null)
        {
            Debug.Log("ShowPopupUI - SamePopupUI Use");
            return null;
        }

        GameObject go = Managers.Resource.Instantiate($"{key}.prefab");
        go.name = key;
        popup = go.GetOrAddComponent<T>();
        _popups.Push(popup);

        go.transform.SetParent(Root.transform);

        return popup as T;
    }


    public void ClosePopupUI(UI_Popup popup)
    {
        if (_popups.Count == 0)
            return;

        if (_popups.Peek() != popup)
        {
            return;
        }
        ClosePopupUI();
    }
    public void ClosePopupUI()
    {
        if (_popups.Count == 0)
            return;
        UI_Popup popup = _popups.Pop();

        Managers.Resource.Destroy(popup.gameObject);
        popup = null;
        _order--;
    }
    public void CloseAllPopupUI()
    {
        while (_popups.Count > 0)
            ClosePopupUI();
    }
    public void Clear()
    {
        CloseAllPopupUI();
        SceneUI = null;
    }

}
