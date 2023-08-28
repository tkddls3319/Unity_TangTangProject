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
        Managers.Object.Spawn<PlayerController>(Vector3.zero);

        Vector3 randPos = new Vector2(Random.Range(-5, 5), Random.Range(-5, 5));
        Managers.Object.Spawn<MonsterController>(randPos,1);

        Managers.UI.ShowJoyStick();
    }
}
