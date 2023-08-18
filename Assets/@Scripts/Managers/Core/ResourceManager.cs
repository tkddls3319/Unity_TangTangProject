using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Object = UnityEngine.Object;

public class ResourceManager
{
    Dictionary<string, Object> _resources = new Dictionary<string, Object>();

    public T Load<T>(string key) where T : Object
    {
        if (_resources.TryGetValue(key, out Object resource))
            return resource as T;

        return null;
    }
    public GameObject Instantiate(string key, Transform parent = null)
    {
        GameObject prefab = Load<GameObject>(key);

        if (prefab == null)
        {
            Debug.Log($"Failed to load prefab : {key}");
            return null;
        }

        Poolable pool = prefab.GetComponent<Poolable>();
        if (pool != null)
            return Managers.Pool.Pop(prefab);

        GameObject go = GameObject.Instantiate(prefab, parent);
        go.name = prefab.name;

        return go;
    }

    public void Destroy(GameObject go)
    {
        if (go == null)
            return;

        if (Managers.Pool.Push(go))
            return;

        GameObject.Destroy(go);
    }

    #region Addressable
    public void LoadAllAsync<T>(string label, Action<string, int, int> callBack) where T : Object
    {
        var onHandler = Addressables.LoadResourceLocationsAsync(label, typeof(T));

        onHandler.Completed += (op) =>
        {
            int loadCount = 0;
            int totalCount = op.Result.Count;

            foreach (var result in op.Result)
            {
                LoadAsync<T>(result.PrimaryKey, (obj) =>
                {
                    loadCount++;
                    callBack?.Invoke(result.PrimaryKey, loadCount, totalCount);
                });
            }
        };
    }
    public void LoadAsync<T>(string key, Action<T> callBack) where T : Object
    {
        if (_resources.TryGetValue(key, out Object resource))
        {
            callBack?.Invoke(resource as T);
            return;
        }

        var onHandler = Addressables.LoadAssetAsync<T>(key);

        onHandler.Completed += (op) =>
       {
           _resources.Add(key, op.Result);
           callBack?.Invoke(op.Result);
       };
    }
    #endregion
}