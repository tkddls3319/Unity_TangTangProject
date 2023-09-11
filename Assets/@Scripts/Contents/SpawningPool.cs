using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningPool : MonoBehaviour
{
    float _monsterInterval = 0.5f;
    int _maxMonsterCount = 100;
    Coroutine _coUpdateSpaningPool;
    GameManager _game;
    public void StartSpawn()
    {
        _game = Managers.Game;
        if (_coUpdateSpaningPool == null)
            _coUpdateSpaningPool = StartCoroutine(CoUpdateSpaningPool());
    }
    IEnumerator CoUpdateSpaningPool()
    {
        while (true)
        {
            int monsterCount = Managers.Object.Monsters.Count;
            if (_maxMonsterCount > monsterCount)
            {
                Vector2 spawnPos = Utils.GenerateMonsterSpawnPosition(Managers.Game.Player.PlayerCenterPos);
                Managers.Object.Spawn<MonsterController>(spawnPos, Random.Range(1, 3));
            }

            yield return new WaitForSeconds(_monsterInterval);
        }
    }
}
