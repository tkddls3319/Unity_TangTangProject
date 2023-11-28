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
    public T MakeWorldSpace<T>(Transform parent = null, string name = null) where T : UI_Base
    {
        if(string.IsNullOrEmpty(name))
            name = typeof(T).Name;


        GameObject go = Managers.Resource.Instantiate(name, pooling: true);
        if (parent != null)
            go.transform.SetParent(parent);

        Canvas canvas = go.GetOrAddComponent<Canvas>(); 
        canvas.renderMode |= RenderMode.WorldSpace;
        canvas.worldCamera = Camera.main;

        return go.GetComponent<T>();    

    }

    public T MakeSubItem<T>(Transform paren = null, string name = null) where T : UI_Base
    {
        if (string.IsNullOrEmpty(name))
            name = typeof(T).Name;

        GameObject go = Managers.Resource.Instantiate(name, paren);
        go.transform.SetParent(paren);

        return go.GetComponent<T>();
    }

    public void ShowSceneUI<T>(string name = null) where T : UI_Scene
    {
        if (string.IsNullOrEmpty(name))
            name = typeof(T).Name;


        GameObject go = Managers.Resource.Instantiate(name);
        Debug.Log(go.name);
        Debug.Log(name);
        T sceneUI = go.GetOrAddComponent<T>();
        SceneUI = sceneUI;
    }
    public T ShowPopupUI<T>(string name = null) where T : UI_Popup
    {
        if (string.IsNullOrEmpty(name))
            name = typeof(T).Name;


        UI_Popup popup = _popups.FirstOrDefault(f => f.name == name);

        if (popup != null)
        {
            Debug.Log("ShowPopupUI - SamePopupUI Use");
            return null;
        }

        GameObject go = Managers.Resource.Instantiate(name);
        go.name = name;
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
