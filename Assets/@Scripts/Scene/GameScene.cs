using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Define;

public class GameScene : BaseScene
{
    SpawningPool _spawningPool;

    private void Awake()
    {
        Init();
    }

    protected override void Init()
    {
        base.Init();
        SceneType = Define.Scene.GameScene;
        LoadStage();
    }

    private void Update()
    {
        Managers.Game.TimeRemaining -= Time.deltaTime;

        if (Managers.Game.TimeRemaining < 30)// 5초에 한번씩
        {
            SpawnWaveReward();
        }
    }
    void LoadStage()
    {
        if (_spawningPool == null)
            _spawningPool = gameObject.GetOrAddComponent<SpawningPool>();

        PlayerController player = Managers.Object.Spawn<PlayerController>(Vector3.zero);

        Camera.main.GetOrAddComponent<CameraController>().Target = player.gameObject;

        Managers.UI.ShowSceneUI<UI_Joystick>();
        Managers.UI.ShowSceneUI<UI_GameScene>();

        if (_spawningPool == null)
            _spawningPool = gameObject.AddComponent<SpawningPool>();

        StartCoroutine(StartWave());
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
        Managers.Game.TimeRemaining = 60;

        DropItemType spawnType = (DropItemType)UnityEngine.Random.Range(0, 2);

        float playerX = Managers.Game.Player.PlayerCenterPos.x;
        float playerY = Managers.Game.Player.PlayerCenterPos.y;
        Vector3 randPos = new Vector2(Random.Range(playerX - 3, playerX + 3), Random.Range(playerY - 3, playerY + 3));

        switch (spawnType)
        {
            case DropItemType.Bomb:
                Managers.Object.Spawn<BombController>(randPos).SetInfo();
                break;
            case DropItemType.Potion:
                Managers.Object.Spawn<PotionController>(randPos).SetInfo();
                break;
        }
    }
    public override void Clear()
    {
    }
}
