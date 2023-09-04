using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers s_instance = null;

    static Managers Instance
    {
        get
        {
            if (s_instance == null)
            {
                GameObject go = GameObject.Find("@Managers");
                if (go == null)
                {
                    go = new GameObject() { name = "@Managers" };
                    go.AddComponent<Managers>();
                }
                DontDestroyOnLoad(go);
                s_instance = go.GetComponent<Managers>();

                Instance?._data.Init();
            }
            return s_instance;
        }
    }

    #region Contentes
    DataManager _data = new();
    GameManager _game = new();
    ObjectManager _object = new();
    PoolManager _pool = new();

    public static DataManager Data { get { return Instance?._data; } }
    public static GameManager Game { get { return Instance?._game; } }
    public static ObjectManager Object { get { return Instance?._object; } }
    public static PoolManager Pool { get { return Instance?._pool; } }
    #endregion

    #region Core
    ResourceManager _resource = new ();
    SceneManager _scene = new ();
    UIManager _ui = new ();

    public static ResourceManager Resource { get { return Instance?._resource; } }
    public static SceneManager Scene { get { return Instance?._scene; } }
    public static UIManager UI { get { return Instance?._ui; } }
    #endregion

}
