using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Define;
using static UnityEditor.MaterialProperty;

public class MainScene : BaseScene
{
    SpawningPool _spawningPool;


    private void Awake()
    {
        base.Init();
        SceneType = Define.Scene.MainScene;

        Managers.Resource.LoadAllAsync<Object>("LoadPrefab", (key, count, totalCount) =>
        {
            if (count == totalCount)
                LoadStage();
        });

    }
    private void Update()
    {
        Managers.Game.TimeRemaining -= Time.deltaTime;

        if (Managers.Game.TimeRemaining < 30)
        {
            SpawnWaveReward();
        }
    }
    void LoadStage()
    {
        PlayerController player = Managers.Object.Spawn<PlayerController>(Vector3.zero);
        _spawningPool = gameObject.GetOrAddComponent<SpawningPool>();

        Camera.main.GetOrAddComponent<CameraController>().Target = player.gameObject;

        Managers.UI.ShowJoyStick();
        Managers.UI.ShowSceneUI<UI_GameScene>();

        if (_spawningPool == null)
            _spawningPool = gameObject.AddComponent<SpawningPool>();


        //  StartCoroutine(StartWave());
        SpawnWaveReward();
        _spawningPool.StartSpawn();
    }

    IEnumerator StartWave()
    {
        yield return new WaitForEndOfFrame();

        SpawnWaveReward();
        _spawningPool.StartSpawn();


        yield break;
    }
    void SpawnWaveReward()
    {

        //Managers.Game.TimeRemaining = 60;

        //DropItemType spawnType = (DropItemType)UnityEngine.Random.Range(0, 3);

        //Vector3 randPos = new Vector2(Random.Range(-5, 5), Random.Range(-5, 5));

        //switch (spawnType)
        //{
        //    case DropItemType.Bomb:
        //            Managers.Object.Spawn<BombController>(randPos).SetInfo();
        //        break;
        //}
    }
    public override void Clear()
    {
    }
}
