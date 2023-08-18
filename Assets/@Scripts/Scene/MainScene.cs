using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScene : MonoBehaviour
{
    void Start()
    {
        Managers.Resource.LoadAllAsync<Object>("LoadPrefab", (key, count, totalCount) =>
        {
            if (count == totalCount)
            {
                StartLoaded();
            }
        });
    }

    void StartLoaded()
    {

    }
}
