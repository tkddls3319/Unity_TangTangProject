using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningPool : MonoBehaviour
{
    float _monsterInterval = 0.1f;
    int _maxMonsterCount = 1000;
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
                Managers.Object.Spawn<MonsterController>(spawnPos, Random.Range(1, 6));
            }

            yield return new WaitForSeconds(_monsterInterval);
        }
    }
}
