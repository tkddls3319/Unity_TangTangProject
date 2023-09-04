using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MainScene : MonoBehaviour
{
    SpawningPool _spawningPool;
    void Start()
    {
        Managers.Resource.LoadAllAsync<Object>("LoadPrefab", (key, count, totalCount) =>
        {
            if (count == totalCount)
                StartLoaded();
        });
    }

    void StartLoaded()
    {
        PlayerController player = Managers.Object.Spawn<PlayerController>(Vector3.zero);
        _spawningPool = gameObject.GetOrAddComponent<SpawningPool>();

        Camera.main.GetOrAddComponent<CameraController>().Target = player.gameObject;

        Managers.UI.ShowJoyStick();
    }
}
